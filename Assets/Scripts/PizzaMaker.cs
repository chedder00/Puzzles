using UnityEngine;
using System.Collections;

public class PizzaMaker : MonoBehaviour {

    public void AlterLayer(GameObject obj)
    {
        obj.SetActive(!obj.active);
    }
}
