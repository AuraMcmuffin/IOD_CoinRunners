using System.Collections;
using UnityEngine;

public class IconManager : MonoBehaviour
{
    public GameObject iconoInvertir;
    public GameObject iconoSlow;
    public GameObject iconoSpeed;
    public GameObject iconoConfusion;
    public GameObject iconoFreeze;


    public void ActivarIconoInvert()
    {
        iconoInvertir.SetActive(true);
    }

    public void DesactivarIconoInvert()
    {
        iconoInvertir.SetActive(false);
    }

    public void ActivarIconoSlow()
    {
        iconoSlow.SetActive(true);
    }

    public void DesactivarIconoSlow()
    {
        iconoSlow.SetActive(false);
    }

    public void ActivarIconoSpeed()
    {
        iconoSpeed.SetActive(true);
    }
    public void DesactivarIconoSpeed()
    {
        iconoSpeed.SetActive(false);
    }

    public void ActivarIconoConfusion()
    {
        iconoConfusion.SetActive(true);
    }
    public void DesactivarIconoConfusion()
    {
        iconoConfusion.SetActive(false);
    }

    public void ActivarIconoFreeze()
    {
        iconoFreeze.SetActive(true);
    }

    public void DesactivarIconoFreeze()
    {
        iconoFreeze.SetActive(false);
    }
}
