using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : Bolt.EntityBehaviour<IBuildingState>
{

   

    public override void Attached()
    {
        state.SetTransforms(state.Transform, transform);
    }

    public override void SimulateOwner()
    {
        if (BoltNetwork.ServerFrame % 100 < 50)
        {
            transform.Translate(Vector3.right * Time.fixedDeltaTime * 10f);
        }
        else
        {
            transform.Translate(Vector3.right * Time.fixedDeltaTime * -10f);
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
