using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintsMenu : MonoBehaviour
{
    public GameObject TabPlane1;
    public GameObject Hint1;
    public GameObject Locked1;
    public GameObject bottone1;

    public GameObject TabPlane2;
    public GameObject Hint2;
    public GameObject Locked2;
    public GameObject bottone2;

    public GameObject TabPlane3;
    public GameObject Hint3;
    public GameObject Locked3;
    public GameObject bottone3;

    // Start is called before the first frame update
    void Start()
    {
        Hint1.SetActive(false);
        Locked1.SetActive(true);

        Hint2.SetActive(false);
        Locked2.SetActive(true);

        Hint3.SetActive(false);
        Locked3.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TaskOnClick1 ()
    {
        Hint1.SetActive(true);
        Locked1.SetActive(false);
    }

    public void TaskOnClick2()
    {
        Hint2.SetActive(true);
        Locked2.SetActive(false);
    }

    public void TaskOnClick3()
    {
        Hint3.SetActive(true);
        Locked3.SetActive(false);
    }
}
