using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundScroller : Scroller
{   

    public override string getType()
    {
        return "ground";
    }

}
