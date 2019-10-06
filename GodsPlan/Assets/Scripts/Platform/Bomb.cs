using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private CircleCollider2D cicrcleCollider;
    private GameObject drake;

    // Start is called before the first frame update
    void Awake()
    {
        cicrcleCollider = this.GetComponent<CircleCollider2D>();
        drake = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircleAll(cicrcleCollider.transform.position, cicrcleCollider.radius/2).Any(x => x.gameObject != gameObject && x.gameObject != drake))
        {
            DoDamage();
            DestroyImmediate(gameObject);
        }
    }

    private void DoDamage()
    {
        EnemyController helper = null;
        if (Physics2D.OverlapCircleAll(cicrcleCollider.transform.position, cicrcleCollider.radius).Any(x => x.gameObject.TryGetComponent<EnemyController>(out helper)))
        {
            DestroyImmediate(helper.gameObject);
        }
    }
}
