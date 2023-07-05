using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardScript : MonoBehaviour
{
    public bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select() {
        if (isSelected) {
            isSelected = false;
            transform.GetChild(0).gameObject.SetActive(false);
        } else {
            isSelected = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
