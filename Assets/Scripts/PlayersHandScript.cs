using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHandScript : MonoBehaviour
{

    // récupère les cartes de la main du joueur
    public List<GameObject> cards = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // selectionne la carte quand on clique dessus, et désélectionne les autres
        if (Input.GetMouseButtonDown(0))
        {
            // récupère la position de la souris
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // pour chaque carte de la main du joueur
            foreach (GameObject card in cards)
            {
                // récupère la position de la carte
                Vector3 cardPos = card.transform.position;
                // récupère la taille de la carte
                Vector3 cardSize = card.GetComponent<SpriteRenderer>().bounds.size;
                // si la souris est sur la carte

                if (mousePos.x > cardPos.x - cardSize.x / 2 && mousePos.x < cardPos.x + cardSize.x / 2 && mousePos.y > cardPos.y - cardSize.y / 2 && mousePos.y < cardPos.y + cardSize.y / 2)
                {
                    card.GetComponent<cardScript>().Select();
                } else {
                    card.GetComponent<cardScript>().isSelected = false;
                    card.transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
