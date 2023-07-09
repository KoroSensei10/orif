using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*

lorsque la boite de collision d'une carte se superpose avec celle d'un emplacement VIDE ( et lorsque le joueur lache le clic gauche de la souris ), on demande au joueur de confirmer s'il s'agit bien de l'emplacement qu'il a choisit. S'il infirme, la carte revient dans sa main, sinon on INSERT la carte dans l'emplacement. Elle devient child de l'emplacement, puis une ou deux PREFAB emplacement sont creés et l'emplacement possédant une carte devient child du plateau.

a voir pour la destruction des cartes lors du déroulement d'une partie

*/

public class magnet : MonoBehaviour
{

    [SerializeField] public var_plateau variables; // permet d'accèder au variables du plateau
    


        
    private GameObject carte; // le gameobject  carte

    [SerializeField] private GameObject plat; // le gameobject plateau

    [SerializeField] private GameObject emplacement; // la prefab emplacement qu'on va instancier, METTRE LA PREFAB sinon le child est instancié est cela cause un crash ( on instancie avec le child et cela cause une boucle infinie ), sinon instantier puis assigné la carte comme un child


    [SerializeField] private bool vide = true; // vraie si si aucune carte n'est child de l'emplacement, faux sinon

    [SerializeField] private bool inser = false; // vraie si une insertion est en cours, faux sinon


    [SerializeField] private float distance = 5f; // distance à laquelle les emplacements sont séparés
    
    [SerializeField] private int compteur = 0; // sert a voir ou se trouve l'emplacement apr rapport aux autres déjà affilié au plateau
    

    private bool util = true; // variable utilitaire


 

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
               
        
        
    }

  

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Collision");
        if(vide ) // a voir  && !(Input.GetMouseButton(0)) // si l'emplacement est vide et le joueur lache le clic gauche de la souris
        {
            vide = false;
            
            // puis on demande confirmation au joueur
            
            col.transform.position = transform.position; // va dans le if de confirmation
            col.transform.parent = transform; // l'emplacement devient le père de la carte
            inser = true;

            // vide reprend la valeur true si infirmation
        }
        
        if(!vide && inser) // si il y a insertion et que l'emplacement n'est plsu vide
        {
            inser = false;
            insertion();
        }
         
        // insertion ne doit s'activer une seule fois : au moment ou le joueur lache le bouton gauche de la souris sur l'emplacement et qu'il a validé son action

    }
    
      
    private void insertion()
    {
        carte = transform.GetChild(0).gameObject; 
        
       
        

        if(variables.plateau.Count == 0) // si la liste est vide
        {
            variables.plateau.Add(carte); // on ajoute la carte à l'identifiant 0 de la liste plateau
            
            Instantiate(emplacement ,new Vector2(transform.position.x - distance ,transform.position.y), Quaternion.identity); // a gauche
            Instantiate(emplacement ,new Vector2(transform.position.x + distance ,transform.position.y), Quaternion.identity); // a droite
            // puis on instantie deux nouveaux emplacements de part et d'autres de celui-ci et on les rend child du plateau
            

        }
        else
        {
            compteur = 0;
            foreach(Transform child in plat.transform) // pour tous les enfants de plateau (tous les emplacements possédant une carte)
            {
                if(child.position.x < transform.position.x) // on compare leur position avec l'emplacement auxquel on vient d'associer une carte
                {
                     compteur += 1;
                }
                else
                {
                    compteur -=1;
                }
            }
            // 
            if(compteur > 0) // si le transform de notre emplacement est superieure à celui de tous les child, compteur > 0, donc on instancie à droite
            {
                variables.plateau.Add(carte);
                Instantiate(emplacement ,new Vector2(transform.position.x + distance ,transform.position.y), Quaternion.identity); // a droite
            }
            else // sinon on instancie à gauche
            {
                variables.plateau.Insert(0,carte);
                Instantiate(emplacement ,new Vector2(transform.position.x - distance ,transform.position.y), Quaternion.identity); // a gauche
        
            }


            transform.parent = plat.transform; // le plateau deveint le père de l'emplacement
            inser = false; // l'insertion est finie

        }

        

    }
        
}
