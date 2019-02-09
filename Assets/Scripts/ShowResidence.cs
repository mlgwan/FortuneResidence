using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowResidence : MonoBehaviour      // Hier werden Gebäude und Zerstörer angezeigt und entfernt und deren Animationen werden abgespielt
{
                                        //Um die Performance zu verbessern, werden einzelne Komponenten wie z.B die Transforms zu Beginn in Variablen gespeichert
                                        // damit sie nicht während der Laufzeit mit den aufwändigen .Find Methoden gesucht werden müssen

    private float scale;
    public GameObject[] buildings;
    private GameObject hohle;
    private GameObject strohhuette;
    private GameObject schloss;
    private GameObject industrie;
    private GameObject neuzeit;
    private GameObject scifi;

    public GameObject hohleEmpty;
    public GameObject strohhuetteEmpty;
    public GameObject industrieEmpty;
    public GameObject schlossEmpty;
    public GameObject neuzeitEmpty;
    public GameObject scifiEmpty;

    private Transform hohleTransform;
    private Transform strohhuetteTransform;
    private Transform schlossTransform;
    private Transform industrieTransform;
    private Transform neuzeitTransform;
    private Transform scifiTransform;

    public Animator[] anims;
    private Animator hohleanim;
    private Animator strohhuetteanim;
    private Animator schlossanim;
    private Animator industrieanim;
    private Animator neuzeitanim;
    private Animator scifianim;
    private int currentAnimation;
    private bool keepPlaying;

    public GameObject vulkanEmpty;
    public GameObject ufoEmpty;
    public GameObject meteorEmpty;


    private GameObject vulkan;
    private GameObject ufo;
    private GameObject meteor;
    private Animator vulkananim;
    private Animator ufoanim;
    private Animator meteoranim;

    public GameObject spinner;
    public bool allowAnimationToPlay;

    public GameObject oneUp;
    public GameObject twoUp;
    public GameObject threeUp;
    public GameObject fourUp;
    public GameObject fiveUp;
    public GameObject sixUp;

    private DefaultTrackableEventHandler oneUpHand;
    private DefaultTrackableEventHandler twoUpHand;
    private DefaultTrackableEventHandler threeUpHand;
    private DefaultTrackableEventHandler fourUpHand;
    private DefaultTrackableEventHandler fiveUpHand;
    private DefaultTrackableEventHandler sixUpHand;

    void Start()
    {
        oneUpHand = oneUp.GetComponent<DefaultTrackableEventHandler>();
        twoUpHand = twoUp.GetComponent<DefaultTrackableEventHandler>();
        threeUpHand = threeUp.GetComponent<DefaultTrackableEventHandler>();
        fourUpHand = fourUp.GetComponent<DefaultTrackableEventHandler>();
        fiveUpHand = fiveUp.GetComponent<DefaultTrackableEventHandler>();
        sixUpHand = sixUp.GetComponent<DefaultTrackableEventHandler>();
      
        allowAnimationToPlay = true;

        vulkan = GetChildWithName(vulkanEmpty, "Vulkan");
        ufo = GetChildWithName(ufoEmpty, "Ufo");
        meteor = GetChildWithName(meteorEmpty, "Meteor");

        vulkananim = vulkan.GetComponent<Animator>();
        ufoanim = ufo.GetComponent<Animator>();
        meteoranim = meteor.GetComponent<Animator>();

       

        scale = 0.1f;   //Größe der Gebäude

        keepPlaying = false; // um sicherzustellen, dass Animationen nicht mehrmals auf einmal abgespielt wird
        currentAnimation = 0;

        buildings = GameObject.FindGameObjectsWithTag("building");
        schloss = GetChildWithName(schlossEmpty, "Schloss");
        hohle = GetChildWithName(hohleEmpty, "Hohle");
        strohhuette = GetChildWithName(strohhuetteEmpty, "Strohhuette");
        industrie = GetChildWithName(industrieEmpty, "Industrie");
        neuzeit = GetChildWithName(neuzeitEmpty, "Neuzeit");
        scifi = GetChildWithName(scifiEmpty, "Scifi");

        hohleanim = hohle.GetComponent<Animator>();
        strohhuetteanim = strohhuette.GetComponent<Animator>();
        schlossanim = schloss.GetComponent<Animator>();
        industrieanim = industrie.GetComponent<Animator>();
        neuzeitanim = neuzeit.GetComponent<Animator>();
        scifianim = scifi.GetComponent<Animator>();

        hohleTransform = hohleEmpty.GetComponent<Transform>();
        strohhuetteTransform = strohhuetteEmpty.GetComponent<Transform>();
        schlossTransform = schlossEmpty.GetComponent<Transform>();
        industrieTransform = industrieEmpty.GetComponent<Transform>();
        neuzeitTransform = neuzeitEmpty.GetComponent<Transform>();
        scifiTransform = scifiEmpty.GetComponent<Transform>();

        anims = new Animator[] { hohleanim, strohhuetteanim, schlossanim, industrieanim, neuzeitanim, scifianim };


        foreach (GameObject building in buildings)                              //Gebäude und Zerstörer werden anfangs "zerstört", indem ihre Scale auf 0 gesetzt wird
        {
            building.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        }
        ufo.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        vulkan.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        meteor.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
    }

    // 
    void Update()
    {

        if (oneUpHand.getUp())      //Im DefaultTrackableEventHandler wurde eine Methode hinzugefüt, um zu prüfen welche Seite oben liegt, je nach Seite wird eine andere Animation abgespielt
        {                           // hier wird zunächst nur festgelegt, welche Animation abgespielt werden soll und der dazugehörige Animator wird aktiviert
            currentAnimation = 0;
            enableAnimator(hohle);
        }

        else if (twoUpHand.getUp())
        {
            currentAnimation = 1;
            enableAnimator(strohhuette);
        }
        else if (threeUpHand.getUp())
        {
            currentAnimation = 2;
            enableAnimator(schloss);
        }
        else if (fourUpHand.getUp())
        {
            currentAnimation = 3;
            enableAnimator(industrie);
        }
        else if (fiveUpHand.getUp())
        {
            currentAnimation = 4;
            enableAnimator(neuzeit);
        }

        else if (sixUpHand.getUp())
        {
            currentAnimation = 5;
            enableAnimator(scifi);
        }

        else if (GameObject.FindWithTag("Residence").GetComponent<DefaultTrackableEventHandler>().getUp() && keepPlaying)
        {

            anims[currentAnimation].Play("Start", 0, 0); //Die Aktuelle Animation wird abgespielt
            if (currentAnimation == 0)
            {
                setPositions(hohleTransform);   //Kurz nach Beginn der Animation wird das Gebäude sichtbar gemacht, dadurch wird Flackern reduziert
            }

            else if (currentAnimation == 1)
            {
                setPositions(strohhuetteTransform);
            }
            else if (currentAnimation == 2)
            {
                setPositions(schlossTransform);
            }
            else if (currentAnimation == 3)
            {
                setPositions(industrieTransform);
            }
            else if (currentAnimation == 4)
            {
                setPositions(neuzeitTransform);
            }
            else if (currentAnimation == 5)
            {
                setPositions(scifiTransform);
            }
            keepPlaying = false;



        }
        
    }

    public void enableAnimator(GameObject building)
    {                                          // deaktiviert die anderen Animatoren und aktiviert den Animator des aktuellen Gebäudes

        foreach (Animator anim in anims)
        {
            anim.enabled = false;
        }
        building.GetComponent<Animator>().enabled = true;
        keepPlaying = true;
    }

    public void setPositions(Transform building)
    {                                          // macht alle Gebäude unsichtbar und macht das aktuelle Gebäude sichtbar

        foreach (GameObject bd in buildings)
        {
            bd.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        }
        building.localScale = new Vector3(scale, scale, scale);
    }



    GameObject GetChildWithName(GameObject obj, string name)   
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    public Animator GetCurrentBuildingAnim()
    {
        return anims[currentAnimation];
    }

    public int GetCurrentBuildingNumber()
    {
        return currentAnimation;
    }

    IEnumerator destroyBuilding(float seconds) //Methode zum zerstören eines Gebäudes mit Zeitverzögerung, die Zeitpunkte wurden einzeln gemessen und sind hard-coded
    {
        yield return new WaitForSecondsRealtime(seconds);
        float temp = scale;
        scale = 0;
        foreach (GameObject building in buildings) //
        {
            building.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        }
        scale = temp;
    }

    IEnumerator resetDestroyerPrefab(Animator destroyeranim, GameObject destroyer, float seconds)
    {

        yield return new WaitForSeconds(seconds); //Methode um einen "Zerstörer" zu zerstören, nach einer Zerstörungsanimation muss das zerstörende Objekt nämlich auch entfernt werden
        destroyeranim.enabled = false;
        destroyer.GetComponent<Transform>().localScale = new Vector3(0, 0, 0);
        allowAnimationToPlay = true;

    }

    public void vulkanDestroy()
    {
        allowAnimationToPlay = false;
        StartCoroutine(resetDestroyerPrefab(vulkananim, vulkan, 29));
        StartCoroutine(destroyBuilding(23));
        vulkananim.enabled = true;
        vulkananim.Play("Destroy", 0, 0);
    }
    public void ufoDestroy()
    {
        allowAnimationToPlay = false;
        StartCoroutine(resetDestroyerPrefab(ufoanim, ufo, 12.36f));
        StartCoroutine(destroyBuilding(6.2f));
        ufoanim.enabled = true;
        ufoanim.Play("Destroy", 0, 0);
    }
    public void meteorDestroy()
    {
        allowAnimationToPlay = false;
        StartCoroutine(destroyBuilding(2.49f));
        StartCoroutine(resetDestroyerPrefab(meteoranim, meteor, 5.45f));
        meteoranim.enabled = true;
        meteoranim.Play("Destroy", 0, 0);
    }
    public void customDestroy(Animator currentBuilding, int buildingNumber) // 0 für Hohle, 1 für Stroh etc, um Umständlichkeiten zu vermeiden wurden die Zerstörungsmethoden einfach mit dem Meteoren aufgerufen
    {
        allowAnimationToPlay = false;

        if (buildingNumber == 0)
        {
            StartCoroutine(destroyBuilding(4.18f));
            StartCoroutine(resetDestroyerPrefab(meteoranim, meteor, 4.18f));
        }

        else if (buildingNumber == 1)
        {
            StartCoroutine(destroyBuilding(6.18f));
            StartCoroutine(resetDestroyerPrefab(meteoranim, meteor, 6.18f));
        }

        else if (buildingNumber == 2)
        {
            StartCoroutine(destroyBuilding(11.18f));
            StartCoroutine(resetDestroyerPrefab(meteoranim, meteor, 11.18f));
        }

        else if (buildingNumber == 3)
        {
            StartCoroutine(destroyBuilding(11.45f));
            StartCoroutine(resetDestroyerPrefab(meteoranim, meteor, 11.45f));
        }

        else if (buildingNumber == 4)
        {
            StartCoroutine(destroyBuilding(5.21f));
            StartCoroutine(resetDestroyerPrefab(meteoranim, meteor, 5.21f));
        }

        else if (buildingNumber == 5)
        {
            StartCoroutine(destroyBuilding(4.58f));
            StartCoroutine(resetDestroyerPrefab(meteoranim, meteor, 4.58f));
        }



        StartCoroutine(resetDestroyerPrefab(meteoranim, meteor, 12f));

        currentBuilding.Play("Destroy", 0, 0);

    }

}