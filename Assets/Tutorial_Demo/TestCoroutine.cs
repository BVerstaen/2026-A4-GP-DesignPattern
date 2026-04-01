using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCoroutine : MonoBehaviour
{
    private void Start()
    {
        Coroutine co = StartCoroutine(CoroutineRoutine());

        if (co != null)
        {
            StopCoroutine(co);
            co = null;
        }


        var curs = CoroutineCounter(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        curs.MoveNext();
        print(curs.Current);
    }

    IEnumerator CoroutineRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(3);
            print("ok");
        }
    }

    System.Collections.Generic.IEnumerator<int> CoroutineCounter(List<int> list)
    {
        foreach (int i in list)
        {
            yield return i;
        }
    }
}
