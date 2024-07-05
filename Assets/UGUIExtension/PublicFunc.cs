using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public partial class PublicFunc 
{

    [Conditional("EnableLog")]
    public static void Log(string str)
    {
        UnityEngine.Debug.Log(str);
    }

}
