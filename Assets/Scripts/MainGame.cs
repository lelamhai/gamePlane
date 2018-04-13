using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

    public bool DisplayCloud()
    {
        if(Singleton.Instance.Point >= 5)
        {
            return true;
        }
        return false;
    }

    public bool DisplayBulletEmeny()
    {
        if(Singleton.Instance.Point >=10)
        {
            return true;
        }
        return false;
    }
}
