using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJugadorEnemigo : MonoBehaviour
{
    public GameObject jugador;
    private Transform Target;
    private Vector3 _direction;
    private Quaternion _lookRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Target = jugador.transform;

        //find the vector pointing from our position to the target
        _direction = (Target.position - transform.position).normalized  ;

        //create the rotation we need to be in to look at the target
        _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime);

        if (transform.rotation == Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime))
        {
            float z = -1, x = -1;
            if (Mathf.Abs(transform.position.z - jugador.transform.position.z) > 0)
            {
                z = 1;
            }

            if (Mathf.Abs(transform.position.x - jugador.transform.position.x) > 0)
            {
                x = 1;
            }

            transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * 10);
        }

    }


}
