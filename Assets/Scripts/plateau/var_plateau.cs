using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Ce script contient la déclaration de toutes les variables communes a tous les éléments du plateau : 

la liste plateau contient les GO cartes,
nbr_cartes compte le nombre de cartes présentent sur le plateau ( obsolète ?)




*/


public class var_plateau : MonoBehaviour
{

    [SerializeField] public List<GameObject> plateau;

    [SerializeField] public int nbr_cartes;

    // Start is called before the first frame update
    void Start()
    {
        nbr_cartes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
