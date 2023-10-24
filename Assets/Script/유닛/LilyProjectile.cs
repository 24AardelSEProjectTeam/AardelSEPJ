using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyProjectile : MonoBehaviour
{



    public float damage = 17f;
    public float laserDuration = 0.5f;
    public GameObject target;
    private Vector3 directionToTarget;
    private bool laserCreated = false;  // �������� �̹� �����Ǿ����� Ȯ���ϴ� ����
    public Transform originatingUnitTransform;
    float scalingSpeed = 10000.0f;
    private void Update()
    {
        
        //transform.localScale += new Vector3(0.25f, scalingSpeed, 0);
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Monster");
            Destroy(this.gameObject);
        }
        else if (!laserCreated)  // �������� ���� �������� �ʾ�����
        {
            CreateLaser();
        }
        if (target && originatingUnitTransform)
        {
            directionToTarget = (target.transform.position - originatingUnitTransform.position).normalized;
            float distanceToTarget = Vector3.Distance(originatingUnitTransform.position, target.transform.position);

            // ������ ������ ���� ����
            transform.localScale = new Vector3(0.25f, Mathf.Min(transform.localScale.y + scalingSpeed, distanceToTarget / 10), 0.25f);

            // �������� ���� ��ġ ���� ����
            transform.position = originatingUnitTransform.position;
        }

        if (Vector2.Distance(transform.position, target.transform.position) <= 0.1f)
        {
            HitTarget();
        }
    }

    void CreateLaser()
    {
        directionToTarget = (target.transform.position - transform.position);
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        //������ ������ ����
        transform.localScale = new Vector3(0.25f, distanceToTarget / 10, 0.25f);

        //�������� ���� ��ġ�� �������� �ʵ��� ������ ����
        transform.position = transform.position + directionToTarget * (distanceToTarget / 2);

        // ������ ȸ�� ����
        transform.rotation = Quaternion.FromToRotation(Vector3.up, directionToTarget);

        HitTarget();
    }

    private IEnumerator DestroyLaserAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        MonsterController monster = other.GetComponent<MonsterController>();
        if (monster != null)
        {
            monster.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    void HitTarget()
    {
        MonsterController monsterScript = target.GetComponent<MonsterController>();
        monsterScript.TakeDamage(damage);
        Debug.Log("hit");
        /*Destroy(gameObject); */ // Destroy the projectile after hitting the target
       
    }
}
