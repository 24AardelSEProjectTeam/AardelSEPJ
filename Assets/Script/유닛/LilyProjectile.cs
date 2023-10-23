using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilyProjectile : MonoBehaviour
{

    //public float speed = 5f;       // Speed of the projectile
    //public GameObject target;     // Target monster
    //public float damage = 17f;    // Damage dealt by the projectile
    //public bool applyPoison; // �� ����� ���� ����
    //public int poisonStacks = 1; // �� ��ø Ƚ��
    //public float poisonDamagePercentage = 0.15f; // �� ������ �ۼ�Ʈ
    //void Update()
    //{
    //    if (target == null)
    //    {
    //        Destroy(gameObject);  // Destroy the projectile if the target is null
    //        return;
    //    }

    //    if (target != null)
    //    {
    //        Vector2 directionToTarget = (Vector2)target.transform.position - (Vector2)transform.position;
    //        float distanceToTarget = directionToTarget.magnitude;

    //        // 1. ��ġ ����
    //        transform.position = (Vector2)target.transform.position - 0.5f * directionToTarget.normalized * distanceToTarget;


    //        // 2. ������ ����
    //        transform.localScale = new Vector3(0.25f, distanceToTarget, 0.25f);

    //        // 3. ȸ�� ����
    //        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
    //        transform.rotation = Quaternion.Euler(0, 0, angle);
    //    }
    //    // Move the projectile towards the target


    //    // Check for collision with the target
    //    if (Vector2.Distance(transform.position, target.transform.position) <= 0.1f)
    //    {
    //        HitTarget();
    //    }
    //}

    //void HitTarget()
    //{
    //    MonsterController monsterScript = target.GetComponent<MonsterController>();
    //    monsterScript.TakeDamage(damage);

    //    Destroy(gameObject);  // Destroy the projectile after hitting the target
    //}


    public float damage = 17f;
    public float laserDuration = 0.5f;
    public GameObject target;
    private Vector3 directionToTarget;
    private bool laserCreated = false;  // �������� �̹� �����Ǿ����� Ȯ���ϴ� ����

    private void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Monster");
        }
        else if (!laserCreated)  // �������� ���� �������� �ʾ�����
        {
            CreateLaser();
        }
    }

    void CreateLaser()
    {
        directionToTarget = (target.transform.position - transform.position).normalized;
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        // ���� ����
        transform.localScale = new Vector3(0.25f, distanceToTarget / 2, 0.25f);  // ���̸� ������ ����� �������� ���ְ� ���� ���̿��� ��Ÿ���� �մϴ�.

        // ���� ����
        transform.rotation = Quaternion.FromToRotation(Vector3.up, directionToTarget);

        // ��ġ ������
        transform.position = transform.position + directionToTarget * (distanceToTarget / 4);  // �������� �߽��� ���ְ� ���� ���̿� ������ �մϴ�.

        laserCreated = true;  // ������ ���� ǥ��

        StartCoroutine(DestroyLaserAfterTime(laserDuration));  // ���ӽð��� ������ �������� ����
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
}
