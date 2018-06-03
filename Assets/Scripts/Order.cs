using UnityEngine;

internal class Order
{
    private string ordertype;
    private GameObject unit;
    private GameObject target;
    private string side;
    private bool executed;

    public Order(string ordertype, GameObject unit, GameObject target, string side)
    {
        this.Ordertype = ordertype;
        this.Unit = unit;
        this.Target = target;
        this.side = side;
        executed = false;
    }

    public GameObject Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    public GameObject Unit
    {
        get
        {
            return unit;
        }

        set
        {
            unit = value;
        }
    }

    public string Ordertype
    {
        get
        {
            return ordertype;
        }

        set
        {
            ordertype = value;
        }
    }

    public string Side
    {
        get
        {
            return side;
        }

        set
        {
            side = value;
        }
    }

    public bool Executed
    {
        get
        {
            return executed;
        }

        set
        {
            executed = value;
        }
    }
}