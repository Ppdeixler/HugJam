using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Resources
{
    //The amount of buildings you have left

    public static int houses;

    public static int firefightbuild;

    public static int hospital;


    public static void GameStart()
    {
        houses = 5;
        firefightbuild = 1;
        hospital = 1;
    }


}
