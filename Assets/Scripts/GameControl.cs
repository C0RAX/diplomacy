using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    //add cancel orders
    public Text turncounter;
    private int playerturnpassed = 0;
    private int turn = 1;
    public Text selectText;
    public Camera viewCamera;
    private string playerside;
    private List<Order> orders = new List<Order> { };
    bool ordering = false;
    bool armyconvoy = false;
    bool fleetconvoy = false;
    bool move = false;
    bool support = false;
    bool reinArmy = false;
    bool reinFleet = false;

    private int reinforcements = 0;

    private GameObject Selected;
    public GameObject armyPrefab;
    public GameObject fleetPrefab;

    public Toggle aToggle;
    public Toggle eToggle;
    public Toggle fToggle;
    public Toggle gToggle;
    public Toggle iToggle;
    public Toggle rToggle;
    public Toggle tToggle;

    public Dropdown orderDropdown;

    public Button armyReinButton;
    public Button fleetReinButton;

    public Text winnerTex;

    //bool endturn = false;

    private void Awake()
    {
        try
        {
            playerside = PlayerData.players.Keys.ElementAt(0);
            //Clear the options of the Dropdown menu
            orderDropdown.ClearOptions();
            winnerTex.text = "";
        }
        catch (IndexOutOfRangeException)
        {
            Debug.Log("No players in dictionary");
            throw;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name.Equals("Map"))
                {
                    Debug.Log(hit.transform.name);
                    selectText.text = "Map";
                }
                else if (hit.transform.name.Equals("flag"))
                {
                    selectText.text = hit.transform.parent.parent.name;
                }
                else
                {
                    Debug.Log(hit.transform.name);
                    selectText.text = hit.transform.name;
                    Selected = hit.transform.gameObject;
                }
            }
        }
        if (ordering)
        {
            if (armyconvoy)
            {
                //army move phase
                if (Input.GetMouseButtonDown(1))
                {// if right button pressed...
                    Debug.Log("right click");
                    if (Selected != null)
                    {// if counter selected
                        Debug.Log("Selected !null");
                        string material = Selected.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
                        if (material.Equals(value: playerside))
                        {
                            Debug.Log("is player side");
                            Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
                            RaycastHit target;
                            if (Physics.Raycast(ray, out target))
                            {
                                if (target.transform.name.Equals("flag"))
                                {
                                    Debug.Log("order pointed to tile/flag " + target.transform.parent.parent.name);
                                    List<GameObject> adjacent = GetComponent<Adjacencies>().adjacencies[target.transform.parent.parent.name];
                                    Debug.Log(adjacent.Count);
                                    Debug.Log(adjacent.ToString());
                                    Debug.Log(Selected.transform.parent.parent.name);
                                    if (Selected.name == "army" && target.transform.parent.parent.parent.name != "SEA")
                                    {
                                        Order(Selected, target.transform.gameObject);
                                    }
                                    selectText.text = target.transform.parent.parent.name;
                                }
                            }
                        }
                    }
                }
            }
            if (fleetconvoy)
            {
                //ship convoy army phase
                if (Input.GetMouseButtonDown(1))
                {// if right button pressed...
                    Debug.Log("right click");
                    if (Selected != null)
                    {// if counter selected
                        Debug.Log("Selected !null");
                        string material = Selected.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
                        if (material.Equals(playerside))
                        {
                            Debug.Log("is player side");
                            Debug.Log(Selected.transform.parent.parent.name);
                            if (Selected.name == "fleet" && Selected.transform.parent.parent.parent.name == "SEA")
                            {
                                Order(Selected, Selected);
                            }
                            selectText.text = Selected.name;
                        }
                    }
                }
            }

            else if (move || support)
            {
                if (Input.GetMouseButtonDown(1))
                {// if right button pressed...
                    Debug.Log("right click");
                    if (Selected != null)
                    {// if counter selected
                        Debug.Log("Selected !null");
                        string material = Selected.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
                        if (material.Equals(playerside))
                        {
                            Debug.Log("is player side");
                            Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
                            RaycastHit target;
                            if (Physics.Raycast(ray, out target))
                            {
                                if (target.transform.name.Equals("flag") || target.transform.tag == "Tile")
                                {
                                    Debug.Log("order pointed to tile/flag " + target.transform.parent.parent.name);
                                    List<GameObject> adjacent = GetComponent<Adjacencies>().adjacencies[target.transform.parent.parent.name];
                                    Debug.Log(adjacent.Count);
                                    Debug.Log(adjacent.ToString());
                                    Debug.Log(Selected.transform.parent.parent.name);
                                    if (adjacent.Contains(Selected.transform.parent.parent.gameObject))
                                    {
                                        Debug.Log("is ajacent tile");
                                        Debug.Log(target.transform.parent.parent.parent.name);
                                        Debug.Log(Selected.transform.parent.parent.parent.name);
                                        if (Selected.name == "army" && target.transform.parent.parent.parent.name != "SEA") { Order(Selected, target.transform.gameObject); }
                                        if (Selected.name == "fleet" && Selected.transform.parent.parent.parent.name != "SEA")
                                        {
                                            if (target.transform.parent.parent.parent.name == "SEA")
                                            {
                                                Order(Selected, target.transform.gameObject);
                                            }
                                        }
                                        else if (Selected.name == "fleet" && Selected.transform.parent.parent.parent.name == "SEA")
                                        {
                                            Order(Selected, target.transform.gameObject);
                                        }
                                    }
                                    selectText.text = target.transform.parent.parent.name;
                                }
                            }

                        }

                    }
                }
            }
            else if (reinArmy || reinFleet)
            {
                if (Input.GetMouseButtonDown(1))
                {// if right button pressed...
                    Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Selected = hit.transform.gameObject;
                    }
                        Debug.Log("right click");
                    if (Selected != null)
                    {// if counter selected
                        Debug.Log("Selected !null");
                        Debug.Log(Selected.transform.name);
                        string material = Selected.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
                        Debug.Log(material);
                        if (material.Equals(playerside))
                        {
                            
                            Debug.Log("is player side");
                            if (reinArmy)
                            {
                                GameObject a = Instantiate(armyPrefab,Selected.transform.parent.parent.Find("Army").transform.position, Selected.transform.rotation);
                                a.transform.parent = Selected.transform.parent.parent.Find("Army");
                                a.transform.name = "army";
                                a.transform.localScale = new Vector3(15,15, 15);
                                a.transform.GetComponent<MeshRenderer>().sharedMaterial = Selected.transform.parent.parent.Find("Flag").Find("flag").GetComponent<MeshRenderer>().sharedMaterial;
                                ordering = false;
                                reinArmy = false;
                                reinforcements--;
                            }
                            else if (reinFleet)
                            {

                                List<GameObject> adjacent = GetComponent<Adjacencies>().adjacencies[Selected.transform.parent.parent.name];
                                foreach (GameObject region in adjacent)
                                {
                                    if (region.transform.parent.name == "SEA")
                                    {
                                        GameObject a = Instantiate(fleetPrefab, Selected.transform.parent.parent.Find("Army").transform.position, Selected.transform.rotation);
                                        a.transform.parent = Selected.transform.parent.parent.Find("Army");
                                        a.transform.name = "fleet";
                                        a.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                                        a.transform.GetComponent<MeshRenderer>().sharedMaterial = Selected.transform.parent.parent.Find("Flag").Find("flag").GetComponent<MeshRenderer>().sharedMaterial;
                                        ordering = false;
                                        reinFleet = false;
                                        reinforcements--;
                                        break;
                                    }
                                   
                                }
                            }

                        }
                    }
                }
            }
            if (reinforcements == 0)
            {
                armyReinButton.interactable = false;
                fleetReinButton.interactable = false;
            }
        }
        setdropdown();
    }

    private void setdropdown()
    {
        List<string> playerorders = new List<string>();
        orderDropdown.options.Clear();
        foreach (Order order in orders)
        {
            if (order.Side == playerside)
            {
                playerorders.Add(order.Unit.transform.parent.parent.name + " " + order.Ordertype + " " + order.Target.transform.parent.parent.name);
                orderDropdown.options.Add(new Dropdown.OptionData(playerorders.Last()));
            }    
        }
    }

    void Order(GameObject select,GameObject target)
    {
        Debug.Log(select.name);
        Debug.Log(target.name);
        Debug.Log(move);
        Debug.Log(support);
        Debug.Log(armyconvoy);
        Debug.Log(fleetconvoy);
        if (move) {
            orders.Add(new Order("MOVE", select, target, playerside));
            move = false;
            Debug.Log("added Move order" + select.name+ target.name);
        }
        else if (support) {
            orders.Add(new Order("SUP", select, target, playerside));
            support = false;
            Debug.Log("added support order" + select.name + target.name);
        }
        else if (armyconvoy) {
            orders.Add(new Order("ACONVOY", select, target, playerside));
            armyconvoy = false;
            Debug.Log("added army convoy order" + select.name + target.name);
        }
        else if (fleetconvoy)
        {
            orders.Add(new Order("FCONVOY", select, target, playerside));
            fleetconvoy = false;
            Debug.Log("added fleet convoy order" + select.name + target.name);
        }
        ordering = false;
    }

    public void Moveclicked()
    {
        ordering = true;
        move = true;
        support = false;
        armyconvoy = false;
        fleetconvoy = false;
        Debug.Log("Move mode");
    }

    public void Supportclicked()
    {
        ordering = true;
        support = true;
        move = false;
        armyconvoy = false;
        fleetconvoy = false;
        Debug.Log("Support mode");
    }

    public void ArmyConvoyClicked()
    {
        ordering = true;
        armyconvoy = true;
        fleetconvoy = false;
        support = false;
        move = false;
        Debug.Log("army convoy mode");
    }

    public void FleetConvoyclicked()
    {
        ordering = true;
        fleetconvoy = true;
        armyconvoy = false;
        support = false;
        move = false;
        Debug.Log("fleet convoy mode");
    }

    public void EndTurnClicked()
    {

        //add logic for all players ended turn 
        playerturnpassed++;
        Debug.Log(playerturnpassed);
        Debug.Log(PlayerData.playerno);

        if (playerturnpassed == PlayerData.playerno)
        {
            Debug.Log("Ending Turn");
            Debug.Log(orders);
            foreach (Order order in orders)
            {
                CalculateOrder(order);
            }
            orders.Clear();
            turn++;
            turncounter.text = turn.ToString();
            playerside = PlayerData.players.Keys.ElementAt(0);
            playerturnpassed = 0;

            aToggle.isOn = false;
            eToggle.isOn = false;
            fToggle.isOn = false;
            gToggle.isOn = false;
            iToggle.isOn = false;
            rToggle.isOn = false;
            tToggle.isOn = false;

            switch (playerside)
            {
                case "Austria":
                    aToggle.isOn = true;
                    break;
                case "England":
                    eToggle.isOn = true;
                    break;
                case "France":
                    fToggle.isOn = true;
                    break;
                case "Germany":
                    gToggle.isOn = true;
                    break;
                case "Italy":
                    iToggle.isOn = true;
                    break;
                case "Russia":
                    rToggle.isOn = true;
                    break;
                case "Turkey":
                    tToggle.isOn = true;
                    break;
                default:
                    break;
            }
            reinforcements = Countfactorys() - Countunits();
            Debug.Log("reinforcements" + reinforcements);
            if (reinforcements > 0)
            {
                armyReinButton.interactable = true;
                fleetReinButton.interactable = true;
            }
            foreach (KeyValuePair<string,string> player in PlayerData.players)
            {
                if (Countfactorys(player.Key) >= 18)
                    {
                    winnerTex.text = player.Value + " Wins!";
                    StartCoroutine(EndGame());

                }
            }
            


        }
        else
        {
            playerside = PlayerData.players.Keys.ElementAt(playerturnpassed);
            switch (playerside)
            {
                case "Austria":
                    aToggle.isOn = true;
                    break;
                case "England":
                    eToggle.isOn = true;
                    break;
                case "France":
                    fToggle.isOn = true;
                    break;
                case "Germany":
                    gToggle.isOn = true;
                    break;
                case "Italy":
                    iToggle.isOn = true;
                    break;
                case "Russia":
                    rToggle.isOn = true;
                    break;
                case "Turkey":
                    tToggle.isOn = true;
                    break;
                default:
                    break;
            }
            reinforcements = Countfactorys() - Countunits();
            Debug.Log("reinforcements" + reinforcements);
            if (reinforcements > 0)
            {
                armyReinButton.interactable = true;
                fleetReinButton.interactable = true;
            }
            Debug.Log(playerside);
        }
        
    }

    private void Retreat(GameObject unit)
    {
        //add check for naval retreat check for sea parent then check for fleet in army object
        bool retreat = false;
        List<GameObject> adjacent = GetComponent<Adjacencies>().adjacencies[unit.transform.parent.parent.name];
        foreach (GameObject obj in adjacent)
        {
            Debug.Log("Retreat: "+ obj.name);
            if (unit.transform.parent.parent.Find("Army").GetChild(0).name == "army" && obj.transform.Find("Army").childCount == 0)
            {
                Debug.Log("army retreat");
                if (obj.transform.Find("Flag").GetChild(0).GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "")
                    .Equals(unit.transform.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "")))
                {
                    unit.transform.parent.parent.Find("Army").GetChild(0).position = new Vector3(obj.transform.Find("Army").position.x, obj.transform.Find("Army").position.y, unit.transform.parent.parent.Find("Army").GetChild(0).position.z);
                    retreat = true;
                }
            }
            else if (unit.transform.parent.parent.Find("Army").GetChild(0).name == "fleet" && obj.transform.Find("Army").childCount == 0)
            {
                Debug.Log("fleet retreat");
                Debug.Log(obj.transform.parent.name);
                Debug.Log(obj.transform.Find("Army").childCount);
                if (obj.transform.parent.name != "SEA")
                {
                    if (unit.transform.parent.parent.parent.name == "SEA")
                    {
                        unit.transform.parent.parent.Find("Army").GetChild(0).position = new Vector3(obj.transform.Find("Army").position.x, obj.transform.Find("Army").position.y, unit.transform.parent.parent.Find("Army").GetChild(0).position.z);
                        retreat = true;
                    }
                }
                else if (obj.transform.parent.name == "SEA")
                {
                    unit.transform.parent.parent.Find("Army").GetChild(0).position = new Vector3(obj.transform.Find("Army").position.x, obj.transform.Find("Army").position.y, unit.transform.parent.parent.Find("Army").GetChild(0).position.z);
                    retreat = true;
                }

                /*if (obj.transform.Find("Army").childCount < 1 
                    && obj.transform.parent.name == "SEA"
                    )
                {
                    unit.transform.parent.parent.Find("Army").GetChild(0).position = new Vector3(obj.transform.Find("Army").position.x, obj.transform.Find("Army").position.y, unit.transform.parent.parent.Find("Army").GetChild(0).position.z);
                    retreat = true;
                }*/
            }
        }
        if (!retreat)
        {
            Destroy(unit.transform.parent.parent.Find("Army").GetChild(0).gameObject);
        }

    }

    bool CalculateOrder(Order order)
    {
        if (order.Executed) { Debug.Log("already executed"); orders.Remove(order); return false; }
        else
        {
            Debug.Log("Executing order");
            Debug.Log(order.Ordertype + " : " + order.Target.name + " : " + order.Unit.name);
            bool win = false;
            switch (order.Ordertype)
            {
                case ("MOVE"):
                    
                    Debug.Log(order.Target.transform.parent.parent.name);
                    if (order.Target.transform.parent.parent.Find("Army").childCount > 0)
                    {
                        int fSupport = 0;
                        int eSupport = 0;
                        foreach (Order otherorder in orders)
                        {
                            if (otherorder.Target == order.Unit)
                            {
                                win = CalculateOrder(otherorder);
                            }
                            if (otherorder.Ordertype.Equals("SUP") && otherorder.Target == order.Target && !otherorder.Unit.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "").Equals(playerside))
                            {
                                eSupport++;
                            }
                            if (otherorder.Ordertype.Equals("SUP") && otherorder.Target == order.Target && otherorder.Unit.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "").Equals(playerside))
                            {
                                fSupport++;
                            }
                        }
                        Debug.Log("support: " + fSupport + " : " + eSupport);
                        if (fSupport > eSupport)
                        {
                            Retreat(order.Target);
                            Debug.Log(order.Target.transform.parent.parent.name);
                            order.Unit.transform.position = new Vector3(order.Target.transform.parent.parent.Find("Army").position.x, order.Target.transform.parent.parent.Find("Army").position.y, order.Unit.transform.position.z);
                            order.Unit.transform.SetParent(order.Target.transform.parent.parent.Find("Army"));
                            if (order.Target.transform.parent.parent.parent.name != "SEA")
                            {
                                order.Target.transform.GetComponent<MeshRenderer>().sharedMaterial = order.Unit.transform.GetComponent<MeshRenderer>().sharedMaterial;
                            }
                            win = true;

                        }
                        order.Executed = true;
                        return win;
                    }
                    else
                    {
                        order.Unit.transform.position = new Vector3(order.Target.transform.parent.parent.Find("Army").position.x, order.Target.transform.parent.parent.Find("Army").position.y, order.Unit.transform.position.z);
                        order.Unit.transform.SetParent(order.Target.transform.parent.parent.Find("Army"));
                        if (order.Target.transform.parent.parent.parent.name != "SEA")
                        {
                            order.Target.transform.GetComponent<MeshRenderer>().sharedMaterial = order.Unit.transform.GetComponent<MeshRenderer>().sharedMaterial;
                        }
                        order.Executed = true;
                    }
                    break;

                case ("ACONVOY"):
                    List<Order> convoys = new List<Order>();
                    Debug.Log(order.Target.transform.parent.parent.name);
                    if (order.Unit != null)
                    {
                        foreach (Order otherorder in orders)
                        {
                            if (otherorder.Target == order.Unit)
                            {
                                win = CalculateOrder(otherorder);
                                return false;
                            }

                        }
                        convoys.Add(order);
                        foreach (Order otherorderA in orders)
                        {
                            List<GameObject> adjacent = GetComponent<Adjacencies>().adjacencies[otherorderA.Unit.transform.parent.parent.name];
                            if (otherorderA.Ordertype == "FCONVOY" 
                                && (adjacent.Contains(convoys.Last().Unit.transform.parent.parent.gameObject) 
                                || adjacent.Contains(order.Unit.transform.parent.parent.gameObject))
                                && !(convoys.Contains(otherorderA)))
                            {
                                foreach (Order otherorderB in orders)
                                {
                                    if (otherorderB.Target == otherorderA.Unit)
                                    {
                                        win = CalculateOrder(otherorderB);
                                    }
                                }
                                if (win) { return false; }
                                else if (adjacent.Contains(order.Target.transform.parent.parent.gameObject))
                                    {
                                    Debug.Log("reached target");
                                        if (order.Target.transform.parent.parent.Find("Army").childCount > 0)
                                        {
                                            int fSupport = 0;
                                            int eSupport = 0;
                                            foreach (Order otherorder in orders)
                                            {
                                                if (otherorder.Ordertype.Equals("SUP") && otherorder.Target == order.Target && !otherorder.Unit.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "").Equals(playerside))
                                                {
                                                    eSupport++;
                                                }
                                                if (otherorder.Ordertype.Equals("SUP") && otherorder.Target == order.Target && otherorder.Unit.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "").Equals(playerside))
                                                {
                                                    fSupport++;
                                                }
                                            }
                                            Debug.Log("support: " + fSupport + " : " + eSupport);
                                            if (fSupport > eSupport)
                                            {
                                                Retreat(order.Target);
                                                Debug.Log(order.Target.transform.parent.parent.name);
                                                order.Unit.transform.position = new Vector3(order.Target.transform.parent.parent.Find("Army").position.x, order.Target.transform.parent.parent.Find("Army").position.y, order.Unit.transform.position.z);
                                                order.Unit.transform.SetParent(order.Target.transform.parent.parent.Find("Army"));
                                                if (order.Target.transform.parent.parent.parent.name != "SEA")
                                                {
                                                    order.Target.transform.GetComponent<MeshRenderer>().sharedMaterial = order.Unit.transform.GetComponent<MeshRenderer>().sharedMaterial;
                                                    win = true;
                                                }

                                            }
                                        order.Executed = true;
                                        return win;
                                        }
                                    else
                                    {
                                        order.Unit.transform.position = new Vector3(order.Target.transform.parent.parent.Find("Army").position.x, order.Target.transform.parent.parent.Find("Army").position.y, order.Unit.transform.position.z);
                                        order.Unit.transform.SetParent(order.Target.transform.parent.parent.Find("Army"));
                                        if (order.Target.transform.parent.parent.parent.name != "SEA")
                                        {
                                            order.Target.transform.GetComponent<MeshRenderer>().sharedMaterial = order.Unit.transform.GetComponent<MeshRenderer>().sharedMaterial;
                                            win = true;
                                        }
                                        order.Executed = true;
                                        return win;
                                    }
                                }

                                }
                                Debug.Log(adjacent.Count);
                                Debug.Log(adjacent.ToString());
                                Debug.Log(otherorderA.Unit.transform.parent.parent.name);
                                convoys.Add(otherorderA);
                            }
                        }
                    break;

                default:
                    return false;
            }
            return false;
        }
    }

    public void CancelOrder() {
        string s = orderDropdown.options.ElementAt(orderDropdown.value).text;
        string[] s2 = s.Split(' ');
        foreach (Order order in orders)
        {
            if (s2[0] == order.Unit.transform.parent.parent.name && s2[1] == order.Ordertype && s2[2] == order.Target.transform.parent.parent.name)
            {
                orders.Remove(order);
                break;
            }
        }
            orderDropdown.options.RemoveAt(orderDropdown.value);
    }

    public void fleetReinforcement()
    {
        ordering = true;
        reinFleet = true;
    }

    public void armyReinforcement()
    {
        ordering = true;
        reinArmy = true;
    }

    public int Countfactorys()
    {
        int count = 0;
        foreach (GameObject factory in GameObject.FindGameObjectsWithTag("Factory"))
        {
            if (factory.name == "factory")
            {
                string material = factory.transform.parent.parent.Find("Flag").Find("flag").GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
                if (material == playerside)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public int Countfactorys(string player)
    {
        int count = 0;
        foreach (GameObject factory in GameObject.FindGameObjectsWithTag("Factory"))
        {
            if (factory.name == "factory")
            {
                string material = factory.transform.parent.parent.Find("Flag").Find("flag").GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
                if (player == material)
                {
                    count++;
                }
            }
        }
        return count;
    }

    public int Countunits()
    {
        int count = 0;
        foreach (GameObject factory in GameObject.FindGameObjectsWithTag("Army"))
        {
            string material = factory.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
            if (material == playerside)
            {
                count++;
            }
        }
        foreach (GameObject factory in GameObject.FindGameObjectsWithTag("Fleet"))
        {
            string material = factory.GetComponent<MeshRenderer>().material.name.Replace(" (Instance)", "");
            if (material == playerside)
            {
                count++;
            }
        }
        return count;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(30);
        GetComponent<FaderScript>().BeginFade(1);
        SceneManager.LoadScene(0);
    }
}