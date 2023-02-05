using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    public Animator rootTipAnimator;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        rootTipAnimator.SetTrigger("tileDestroy");
    }
}
