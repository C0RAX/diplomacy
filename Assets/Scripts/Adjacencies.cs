using System;
using System.Collections.Generic;
using UnityEngine;

public class Adjacencies : MonoBehaviour {

    public Dictionary<string, List<GameObject>> adjacencies= new Dictionary<string, List<GameObject>>();


    private void Start()
    {
        //ocean tiles
        adjacencies.Add("NAO", new List<GameObject> { GameObject.Find("NWG"), GameObject.Find("CLY"), GameObject.Find("LIV"), GameObject.Find("IRI"), GameObject.Find("MAO") });
        adjacencies.Add("NWG", new List<GameObject> { GameObject.Find("BAR"), GameObject.Find("NWY"), GameObject.Find("NTH"), GameObject.Find("CLY"), GameObject.Find("EDI"), GameObject.Find("NAO") });
        adjacencies.Add("BAR", new List<GameObject> { GameObject.Find("NWG"), GameObject.Find("STP"), GameObject.Find("NWY")});
        adjacencies.Add("MAO", new List<GameObject> { GameObject.Find("NAO"), GameObject.Find("IRI"), GameObject.Find("ENG"), GameObject.Find("BRE"), GameObject.Find("GAS"), GameObject.Find("SPA"), GameObject.Find("POR"), GameObject.Find("WES"), GameObject.Find("NAF") });
        adjacencies.Add("IRI", new List<GameObject> { GameObject.Find("NAO"), GameObject.Find("LIV"), GameObject.Find("WAL"), GameObject.Find("ENG"), GameObject.Find("MAO") });
        adjacencies.Add("ENG", new List<GameObject> { GameObject.Find("IRI"), GameObject.Find("WAL"), GameObject.Find("LON"), GameObject.Find("NTH"), GameObject.Find("MAO"), GameObject.Find("BEL"), GameObject.Find("PIC"), GameObject.Find("BRE") });
        adjacencies.Add("NTH", new List<GameObject> { GameObject.Find("NWG"), GameObject.Find("EDI"), GameObject.Find("YOR"), GameObject.Find("LON"), GameObject.Find("NWY"), GameObject.Find("SKA"), GameObject.Find("HEL"), GameObject.Find("HOL"), GameObject.Find("BEL"), GameObject.Find("ENG") });
        adjacencies.Add("SKA", new List<GameObject> { GameObject.Find("NTH"), GameObject.Find("NWY"), GameObject.Find("SWE"), GameObject.Find("DEN")});
        adjacencies.Add("HEL", new List<GameObject> { GameObject.Find("NTH"), GameObject.Find("DEN"), GameObject.Find("HOL"), GameObject.Find("KIE") });
        adjacencies.Add("BAL", new List<GameObject> { GameObject.Find("BOT"), GameObject.Find("SWE"), GameObject.Find("DEN"), GameObject.Find("KIE"), GameObject.Find("BER"), GameObject.Find("PRU"), GameObject.Find("LVN") });
        adjacencies.Add("BOT", new List<GameObject> { GameObject.Find("BAL"), GameObject.Find("SWE"), GameObject.Find("FIN"), GameObject.Find("STP"), GameObject.Find("LVN") });
        adjacencies.Add("WES", new List<GameObject> { GameObject.Find("MAO"), GameObject.Find("NAF"), GameObject.Find("TUN"), GameObject.Find("TYS"), GameObject.Find("SPA"), GameObject.Find("LYO") });
        adjacencies.Add("LYO", new List<GameObject> { GameObject.Find("WES"), GameObject.Find("SPA"), GameObject.Find("MAR"), GameObject.Find("PIE"), GameObject.Find("TUS"), GameObject.Find("TYS") });
        adjacencies.Add("TYS", new List<GameObject> { GameObject.Find("LYO"), GameObject.Find("WES"), GameObject.Find("TUN"), GameObject.Find("TUS"), GameObject.Find("ROM"), GameObject.Find("NAP"), GameObject.Find("ION") });
        adjacencies.Add("ION", new List<GameObject> { GameObject.Find("TUN"), GameObject.Find("TYS"), GameObject.Find("NAP"), GameObject.Find("APU"), GameObject.Find("ADR"), GameObject.Find("ALB"), GameObject.Find("GRE"), GameObject.Find("AEG"), GameObject.Find("EAS") });
        adjacencies.Add("ADR", new List<GameObject> { GameObject.Find("VEN"), GameObject.Find("TRI"), GameObject.Find("ALB"), GameObject.Find("ION"), GameObject.Find("APU") });
        adjacencies.Add("AEG", new List<GameObject> { GameObject.Find("ION"), GameObject.Find("GRE"), GameObject.Find("BUL"), GameObject.Find("CON"), GameObject.Find("SMY"), GameObject.Find("EAS") });
        adjacencies.Add("AES", new List<GameObject> { GameObject.Find("ION"), GameObject.Find("AEG"), GameObject.Find("SMY"), GameObject.Find("SYR")});
        adjacencies.Add("BLA", new List<GameObject> { GameObject.Find("SEV"), GameObject.Find("ARM"), GameObject.Find("ANK"), GameObject.Find("CON"), GameObject.Find("BUL"), GameObject.Find("RUM") });

        //GB Tiles
        adjacencies.Add("CLY", new List<GameObject> { GameObject.Find("NAO"), GameObject.Find("NWG"), GameObject.Find("LIV"), GameObject.Find("EDI") });
        adjacencies.Add("EDI", new List<GameObject> { GameObject.Find("CLY"), GameObject.Find("NWG"), GameObject.Find("LIV"), GameObject.Find("YOR"), GameObject.Find("NTH") });
        adjacencies.Add("LIV", new List<GameObject> { GameObject.Find("IRI"), GameObject.Find("NAO"), GameObject.Find("CLY"), GameObject.Find("EDI"), GameObject.Find("YOR"), GameObject.Find("WAL") });
        adjacencies.Add("YOR", new List<GameObject> { GameObject.Find("EDI"), GameObject.Find("NWG"), GameObject.Find("LON"), GameObject.Find("WAL"), GameObject.Find("LIV") });
        adjacencies.Add("WAL", new List<GameObject> { GameObject.Find("IRI"), GameObject.Find("LIV"), GameObject.Find("YOR"), GameObject.Find("LON"), GameObject.Find("ENG") });
        adjacencies.Add("LON", new List<GameObject> { GameObject.Find("YOR"), GameObject.Find("NTH"), GameObject.Find("ENG"), GameObject.Find("WAL")});

        //FRA Tiles
        adjacencies.Add("BRE", new List<GameObject> { GameObject.Find("ENG"), GameObject.Find("PIC"), GameObject.Find("PAR"), GameObject.Find("GAS"), GameObject.Find("MAO") });
        adjacencies.Add("PIC", new List<GameObject> { GameObject.Find("ENG"), GameObject.Find("BEL"), GameObject.Find("BUR"), GameObject.Find("PAR"), GameObject.Find("BRE") });
        adjacencies.Add("PAR", new List<GameObject> { GameObject.Find("PIC"), GameObject.Find("BUR"), GameObject.Find("GAS"), GameObject.Find("BRE")});
        adjacencies.Add("GAS", new List<GameObject> { GameObject.Find("PAR"), GameObject.Find("BUR"), GameObject.Find("MAR"), GameObject.Find("SPA"), GameObject.Find("MAO") });
        adjacencies.Add("BUR", new List<GameObject> { GameObject.Find("BEL"), GameObject.Find("RUH"), GameObject.Find("MUN"), GameObject.Find("MAR"), GameObject.Find("GAS"), GameObject.Find("PAR"), GameObject.Find("PIC") });
        adjacencies.Add("MAR", new List<GameObject> { GameObject.Find("BUR"), GameObject.Find("PIE"), GameObject.Find("LYO"), GameObject.Find("SPA"), GameObject.Find("GAS") });

        //GERM TILES
        adjacencies.Add("KIE", new List<GameObject> { GameObject.Find("DEN"), GameObject.Find("BAL"), GameObject.Find("BER"), GameObject.Find("MUN"), GameObject.Find("RUH"), GameObject.Find("HOL"), GameObject.Find("HEL") });
        adjacencies.Add("BER", new List<GameObject> { GameObject.Find("BAL"), GameObject.Find("PRU"), GameObject.Find("SIL"), GameObject.Find("MUN"), GameObject.Find("KIE") });
        adjacencies.Add("PRU", new List<GameObject> { GameObject.Find("BAL"), GameObject.Find("LVN"), GameObject.Find("WAR"), GameObject.Find("SIL"), GameObject.Find("BER")});
        adjacencies.Add("RUH", new List<GameObject> { GameObject.Find("HOL"), GameObject.Find("KIE"), GameObject.Find("MUN"), GameObject.Find("BUR"), GameObject.Find("BEL") });
        adjacencies.Add("MUN", new List<GameObject> { GameObject.Find("KIE"), GameObject.Find("BER"), GameObject.Find("SIL"), GameObject.Find("BOH"), GameObject.Find("TYR"), GameObject.Find("BUR"), GameObject.Find("RUH") });
        adjacencies.Add("SIL", new List<GameObject> { GameObject.Find("BER"), GameObject.Find("PRU"), GameObject.Find("WAR"), GameObject.Find("GAL"), GameObject.Find("BOH"), GameObject.Find("MUN") });

        //RUS Tiles
        adjacencies.Add("STP", new List<GameObject> { GameObject.Find("BAR"), GameObject.Find("MOS"), GameObject.Find("LVN"), GameObject.Find("BOT"), GameObject.Find("FIN") });
        adjacencies.Add("MOS", new List<GameObject> { GameObject.Find("STP"), GameObject.Find("SEV"), GameObject.Find("UKR"), GameObject.Find("WAR"), GameObject.Find("LVN") });
        adjacencies.Add("SEV", new List<GameObject> { GameObject.Find("MOS"), GameObject.Find("ARM"), GameObject.Find("BLA"), GameObject.Find("RUM"), GameObject.Find("UKR") });
        adjacencies.Add("UKR", new List<GameObject> { GameObject.Find("MOS"), GameObject.Find("SEV"), GameObject.Find("RUM"), GameObject.Find("GAL"), GameObject.Find("WAR") });
        adjacencies.Add("WAR", new List<GameObject> { GameObject.Find("LVN"), GameObject.Find("MOS"), GameObject.Find("UKR"), GameObject.Find("GAL"), GameObject.Find("SIL"), GameObject.Find("PRU") });
        adjacencies.Add("LVN", new List<GameObject> { GameObject.Find("STP"), GameObject.Find("MOS"), GameObject.Find("WAR"), GameObject.Find("PRU"), GameObject.Find("BAL"), GameObject.Find("BOT") });

        //TURK Tiles
        adjacencies.Add("ARM", new List<GameObject> { GameObject.Find("SYR"), GameObject.Find("SMY"), GameObject.Find("ANK"), GameObject.Find("BLA"), GameObject.Find("SEV") });
        adjacencies.Add("SYR", new List<GameObject> { GameObject.Find("ARM"), GameObject.Find("EAS"), GameObject.Find("SMY")});
        adjacencies.Add("SMY", new List<GameObject> { GameObject.Find("ARM"), GameObject.Find("SYR"), GameObject.Find("EAS"), GameObject.Find("AEG"), GameObject.Find("CON"), GameObject.Find("ANK") });
        adjacencies.Add("CON", new List<GameObject> { GameObject.Find("BLA"), GameObject.Find("ANK"), GameObject.Find("SMY"), GameObject.Find("AEG"), GameObject.Find("BUL") });
        adjacencies.Add("ANK", new List<GameObject> { GameObject.Find("LIV"), GameObject.Find("MOS"), GameObject.Find("UKR"), GameObject.Find("GAL"), GameObject.Find("SIL"), GameObject.Find("PRU") });

        //IALY Tiles
        adjacencies.Add("PIE", new List<GameObject> { GameObject.Find("TYR"), GameObject.Find("VEN"), GameObject.Find("TUS"), GameObject.Find("LYO"), GameObject.Find("MAR") });
        adjacencies.Add("VEN", new List<GameObject> { GameObject.Find("TYR"), GameObject.Find("TRI"), GameObject.Find("ADR"), GameObject.Find("APU"), GameObject.Find("ROM"), GameObject.Find("TUS"), GameObject.Find("PIE") });
        adjacencies.Add("APU", new List<GameObject> { GameObject.Find("VEN"), GameObject.Find("ADR"), GameObject.Find("ION"), GameObject.Find("NAP"), GameObject.Find("ROM") });
        adjacencies.Add("NAP", new List<GameObject> { GameObject.Find("APU"), GameObject.Find("ION"), GameObject.Find("TYS"), GameObject.Find("ROM")});
        adjacencies.Add("ROM", new List<GameObject> { GameObject.Find("TUS"), GameObject.Find("VEN"), GameObject.Find("APU"), GameObject.Find("NAP"), GameObject.Find("TYS")});
        adjacencies.Add("TUS", new List<GameObject> { GameObject.Find("PIE"), GameObject.Find("VEN"), GameObject.Find("ROM"), GameObject.Find("TYS"), GameObject.Find("LYO")});

        //AUS Tiles
        adjacencies.Add("BOH", new List<GameObject> { GameObject.Find("SIL"), GameObject.Find("GAL"), GameObject.Find("VIE"), GameObject.Find("TYR"), GameObject.Find("MUN") });
        adjacencies.Add("GAL", new List<GameObject> { GameObject.Find("WAR"), GameObject.Find("UKR"), GameObject.Find("RUM"), GameObject.Find("BUD"), GameObject.Find("VIE"), GameObject.Find("BOH"), GameObject.Find("SIL") });
        adjacencies.Add("BUD", new List<GameObject> { GameObject.Find("RUM"), GameObject.Find("SER"), GameObject.Find("TRI"), GameObject.Find("VIE"), GameObject.Find("GAL") });
        adjacencies.Add("VIE", new List<GameObject> { GameObject.Find("GAL"), GameObject.Find("BUD"), GameObject.Find("TRI"), GameObject.Find("TYR"), GameObject.Find("BOH") });
        adjacencies.Add("TRI", new List<GameObject> { GameObject.Find("VIE"), GameObject.Find("BUD"), GameObject.Find("SER"), GameObject.Find("ALB"), GameObject.Find("ADR"), GameObject.Find("VEN"), GameObject.Find("TYR") });
        adjacencies.Add("TYR", new List<GameObject> { GameObject.Find("MUN"), GameObject.Find("BOH"), GameObject.Find("VIE"), GameObject.Find("TRI"), GameObject.Find("VEN"), GameObject.Find("PIE") });

        //SPAIN Tiles
        adjacencies.Add("SPA", new List<GameObject> { GameObject.Find("GAS"), GameObject.Find("MAR"), GameObject.Find("LYO"), GameObject.Find("WES"), GameObject.Find("POR"), GameObject.Find("MAO") });
        adjacencies.Add("POR", new List<GameObject> { GameObject.Find("MAO"), GameObject.Find("SPA") });

        //AFIRCA Tiles
        adjacencies.Add("NAF", new List<GameObject> { GameObject.Find("MAO"), GameObject.Find("WES"), GameObject.Find("TUN") });
        adjacencies.Add("TUN", new List<GameObject> { GameObject.Find("NAF"), GameObject.Find("WES"), GameObject.Find("TYS"), GameObject.Find("ION") });

        //LOWLA Tiles
        adjacencies.Add("BEL", new List<GameObject> { GameObject.Find("ENG"), GameObject.Find("NTH"), GameObject.Find("HOL"), GameObject.Find("KIE"), GameObject.Find("RUH"), GameObject.Find("BUR"), GameObject.Find("PIC") });
        adjacencies.Add("HOL", new List<GameObject> { GameObject.Find("HEL"), GameObject.Find("KIE"), GameObject.Find("RUH"), GameObject.Find("BEL"), GameObject.Find("NTH") });

        //SCAND Tiles
        adjacencies.Add("NWY", new List<GameObject> { GameObject.Find("NWG"), GameObject.Find("BAR"), GameObject.Find("STP"), GameObject.Find("FIN"), GameObject.Find("SWE"), GameObject.Find("SKA"), GameObject.Find("NTH") });
        adjacencies.Add("SWE", new List<GameObject> { GameObject.Find("NWY"), GameObject.Find("FIN"), GameObject.Find("BOT"), GameObject.Find("BAL"), GameObject.Find("DEN"), GameObject.Find("SKA") });
        adjacencies.Add("DEN", new List<GameObject> { GameObject.Find("SKA"), GameObject.Find("SWE"), GameObject.Find("BAL"), GameObject.Find("KIE"), GameObject.Find("HEL"), GameObject.Find("NTH") });
        adjacencies.Add("FIN", new List<GameObject> { GameObject.Find("NWY"), GameObject.Find("BAR"), GameObject.Find("STP"), GameObject.Find("BOT"), GameObject.Find("SWE") });

        //BALKEN Tiles
        adjacencies.Add("RUM", new List<GameObject> { GameObject.Find("UKR"), GameObject.Find("SEV"), GameObject.Find("BLA"), GameObject.Find("BUL"), GameObject.Find("SER"), GameObject.Find("BUD"),GameObject.Find("GAL") });
        adjacencies.Add("BUL", new List<GameObject> { GameObject.Find("RUM"), GameObject.Find("BLA"), GameObject.Find("CON"), GameObject.Find("AEG"), GameObject.Find("GRE"), GameObject.Find("SER") });
        adjacencies.Add("GRE", new List<GameObject> { GameObject.Find("BUL"), GameObject.Find("AEG"), GameObject.Find("ION"), GameObject.Find("ALB"), GameObject.Find("SER") });
        adjacencies.Add("SER", new List<GameObject> { GameObject.Find("BUD"), GameObject.Find("RUM"), GameObject.Find("BUL"), GameObject.Find("GRE"), GameObject.Find("ALB"), GameObject.Find("TRI") });
        adjacencies.Add("ALB", new List<GameObject> { GameObject.Find("SER"), GameObject.Find("GRE"), GameObject.Find("ION"), GameObject.Find("ADR"), GameObject.Find("TRI")});

        /*foreach (KeyValuePair<string, List<GameObject>> entry in adjacencies)
        {
            Debug.Log("KEY:");
            Debug.Log(entry.Key.ToString());

            foreach (GameObject o in entry.Value)
            {
                Debug.Log(o.name);
            }
             
        }
        */
        
    }

}
