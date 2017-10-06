using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodedSphere : MonoBehaviour
{

    //Coefficient of Restitution 
    float CoR, mass, Mass = 1.0f, timerlimit = 1.0f;
    public Vector3 accelaration, velocity;
    private bool collisionOccurred = false;
    private CodedSphere occurredWith;
    planeScript[] thePlanes;
    CodedSphere[] theSpheres;
    int setTimer = 3;



    
     // Use this for initialization
    void Start()
    {

        mass = UnityEngine.Random.Range(0.5f, 1.0f);
        CoR = mass * 0.5f;
        this.transform.localScale = new Vector3(mass, mass, mass);
        thePlanes = FindObjectsOfType<planeScript>();

     }

    // Update is called once per frame
    void Update()
    {
        
        sphereAndPlane();

        if(setTimer > 0)
        {

            setTimer--;
        }

        else
        {
            collisionOccurred = false;
            setTimer = 3;
	}

        velocity -= velocity * 0.01f;


    }

 
    /// <summary>
    /// This returns the parallel component of the vector v parallel to n
    /// </summary>
    /// <param name="v"> Vector to Decompose</param>
    /// <param name="n"> Unit vector to decompose parallel to, this is usually a unit vector</param>
    /// <returns></returns>
    Vector3 parallelComponent(Vector3 v, Vector3 n)
    {

        Vector3 n1 = n.normalized;

        return Vector3.Dot(v, n1) * n1;

    }

    /// <summary>
    /// This returns the perpendicular component of the vector v parallel to n
    /// </summary>
    /// <param name="v"> Vector to Decompose</param>
    /// <param name="n"> Unit vector to decompose parallel to, this is usually a unit vector</param>
    /// <returns></returns>
    Vector3 perpendicularComponent(Vector3 v, Vector3 n)
    {


        return v - parallelComponent(v, n);


    }
    private void OnTriggerEnter(Collider collision)
    {


        if (!collisionOccurred)
        {
            CodedSphere otherSphere = collision.gameObject.GetComponent<CodedSphere>();

            if (otherSphere) collidesWith(otherSphere);
        }


            //collisionOccurred = false;

            planeScript otherPlane = collision.gameObject.GetComponent<planeScript>();

            if (otherPlane) collidesWith(otherPlane);
        
    }

    private void collidesWith(planeScript otherPlane)
    {
        throw new NotImplementedException();
    }

    private void collidesWith(CodedSphere otherSphere)
    {

       
            Vector3 n = (transform.position - otherSphere.transform.position).normalized;

            Vector3 thisPerp = perpendicularComponent(velocity, n);
            Vector3 otherPerp = perpendicularComponent(otherSphere.velocity, n);

            Vector3 u1 = CoR * parallelComponent(velocity, n);
            Vector3 u2 = CoR * parallelComponent(otherSphere.velocity, n);

            float M1 = Mass, M2 = otherSphere.Mass;

            Vector3 v1 = ((M1 - M2) / (M1 + M2)) * u1 + (2 * M2 / (M1 + M2)) * u2;
            Vector3 v2 = ((M2 - M1) / (M1 + M2)) * u2 + (2 * M1 / (M1 + M2)) * u1;

            velocity = thisPerp + v1;

            // this.transform.position -= u1 * Time.deltaTime;
           

            otherSphere.newVelocityAfterCollisionwith(this, otherPerp + v2);

          
        
 
    }

    private void newVelocityAfterCollisionwith(CodedSphere codedSphere, Vector3 newVelocity)
    {
        velocity = newVelocity;
        collisionOccurred = true;
        occurredWith = codedSphere;

       }



    void sphereAndPlane()
    {
        accelaration = 9.8f * Vector3.down;  //Physics.gravity
        velocity += accelaration * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;


        foreach (planeScript thePlane in thePlanes)
        {
            Vector3 fromPlaneToSphere = transform.position - thePlane.transform.position;
            Vector3 planeNormal = thePlane.transform.up;


            //Used to reverse the normals acting on the sphere to make it bounce
            if (parallelComponent(fromPlaneToSphere, planeNormal).magnitude < (this.transform.localScale.x / 2))

            {
                //pushes the sphere back above the surface and allows the perpendicular velocity to still act on the sphere
                transform.position -= parallelComponent(velocity * Time.deltaTime, planeNormal);

                velocity = perpendicularComponent(velocity, planeNormal) - CoR * parallelComponent(velocity, planeNormal);


            }
        }



    }
    /*
    void conservationOfMomentum(Vector3 m1,Vector3 m2,Vector3 u1, Vector3 u2)
    {
        Vector3 v1 = new Vector3();
        Vector3 v2 = new Vector3();
        v1.x =((m1.x-m2.x)/ (m1.x+m2.x )*u1.x)+(((2 * m2.x) / (m1.x + m2.x)) * u2.x);
        v1.y = ((m1.y - m2.y) / (m1.y + m2.y) * u1.y) + (((2 * m2.y) / (m1.y + m2.y)) * u2.y);
        v1.z = ((m1.z - m2.z) / (m1.z + m2.z) * u1.z) + (((2 * m2.z) / (m1.z + m2.z)) * u2.z);

        v2.x = ((m2.x - m1.x) / (m1.x + m2.x) / u2.x) + (((2 * m1.x)/(m1.x+m2.x))*u1.x);
        v2.x = ((m2.y - m1.y) / (m1.y + m2.y) / u2.y) + (((2 * m1.y) / (m1.y + m2.y)) * u1.y);
       
        v2.x = ((m2.z - m1.z) / (m1.z + m2.z) / u2.z) + (((2 * m1.z) / (m1.z + m2.z)) * u1.z);

        velocity = v1;
        sphere2.velocity = v2;
    }
    */
}




