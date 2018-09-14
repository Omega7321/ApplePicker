using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]

    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    public List<GameObject> basketList;

    void Start()
    {
        for (int i = 0; i < numBaskets; i++)
        {

            basketList = new List<GameObject>();

            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);


        }
    }

    public void AppleDestroyed()
        {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach ( GameObject tGO in tAppleArray )
            {
                Destroy( tGO );
            }

            int basketIndex = basketList.Count-1;
            GameObject tBasketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(tBasketGO);

            if ( basketList.Count == 0 )
            {
                //SceneManager.LoadScene("Scene_0");
            }
        //Commented out due to game restarting upon losing a single basket,
        //either the basket count isn't the right value or the value isn't set up correctly or something 
        //unintended is happening with 'Apple Destroyed'

        //it is also important to note that only the first basket is removed upon missing an apple,
        //the other two baskets will remain no matter what.

        //I am also having trouble with having the High Score update once the Score is surpassed.

        //-Thanks, Mark
	}
	
	void Update () {
		
	}
}
