using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGenerate : MonoBehaviour
{
    private GeneratingByPrefab _posLastFloor;

    public GameObject PrefabFinish;
	// Use this for initialization
	void Start ()
	{
	    _posLastFloor = GetComponent<GeneratingByPrefab>();
	    StartCoroutine(GenerateFinish());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GenerateFinish()
    {
        yield return new WaitForEndOfFrame();
        var pos = _posLastFloor.LastPos  + new Vector3(0, 0, PrefabFinish.GetComponent<BoxCollider>().size.z
            * PrefabFinish.transform.localScale.z/2 - 2f);
        PrefabFinish.transform.position = pos;
    }
}
