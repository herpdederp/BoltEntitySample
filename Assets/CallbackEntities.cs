using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallbackEntities : Bolt.GlobalEventListener
{
    [SerializeField]
    List<BoltEntity> entities = new List<BoltEntity>();

    [SerializeField]
    List<GameObject> fakeEntities = new List<GameObject>();




    public override void SceneLoadLocalDone(string scene)
    {
        if (BoltNetwork.IsServer)
        {
            foreach (BoltEntity entity in entities)
            {
                BoltNetwork.Attach(entity.gameObject);
                // GameObject.Destroy(entity);
                //entity.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (BoltEntity entity in entities)
            {
                GameObject.Destroy(entity.gameObject);
            }
        }


        if (BoltNetwork.IsServer)
        {
            foreach (GameObject go in fakeEntities)
            {
                FakeEntity FE = go.GetComponent<FakeEntity>();
                if (FE != null)
                {
                    BoltNetwork.Instantiate(FE.source, go.transform.position, go.transform.rotation);
                    GameObject.Destroy(go);
                }
            }
        }
        else
        {
            foreach (GameObject go in fakeEntities)
            {
                GameObject.Destroy(go);
            }
        }



    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
