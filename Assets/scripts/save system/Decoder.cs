using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Decoder
{
    // Start is called before the first frame update
    public static string Decode(string entry, int bit)
    {


        string dayPart1;
        string dayPart2;
        string dayPart3;

        //splitted aray of day strings
        string[] splittedDay = {"", "", ""};
        string[] decodedDay = {"", "", ""};

        //possible info
        string[] types = {"delivery", "build", "services"};
        string[] timings = {"on time", "due today", "late"};
        string[] data = {"", "", ""};

        //setting of int1
        dayPart1 = entry.Substring(0,2);
        splittedDay[0] = dayPart1;
        //Debug.Log(splittedDay[2]);

        //setting of int2
        dayPart2 = entry.Substring(2,2);
        splittedDay[1] = dayPart2;
        //Debug.Log(splittedDay[1]);
        
        //setting of int3
        dayPart3 = entry.Substring(4,2);
        splittedDay[2] = dayPart3;
        //Debug.Log(splittedDay[2]);


        //decodes numbers
        decodedDay[0] = types[int.Parse(dayPart1)];
        decodedDay[1] = data[int.Parse(dayPart2)];
        decodedDay[2] = timings[int.Parse(dayPart3)];






        if(bit == 1)
        {
            return decodedDay[0];
        }
        else if(bit == 2){
            return decodedDay[1];
        }
        else if(bit == 3){
            return decodedDay[2];
        }
        else{
            return "tf is this";
        }
    }
}

            // if(dayPart3 == "01")
            // {
            //     return "on Time";
            // }
            // if(dayPart3 == "02")
            // {
            //     return "due Today";
            // }
            // if(dayPart3 == "03")
            // {
            //     return "late";
            // }