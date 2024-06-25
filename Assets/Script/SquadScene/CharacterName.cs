using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterName : MonoBehaviour
{
    public Text text;
    public Text UnitText;
    public GameObject UnitInfos;
    public void OnButtonClick()
    {
        if (!UnitInfos.activeSelf)
        {
            UnitInfos.SetActive(true);
            Debug.Log("Unitinfostrue");
            TextChange();


        }
        else
        {
            UnitInfos.SetActive(false);
            Debug.Log("Unitinfosfalse");
        }

        Debug.Log("Unitinfos");

    }

    public void TextChange()
    {
        if (text.text.Contains("Į��"))
        {
            UnitText.text = "\r\n���� �ӹ����� �����ϰ� �ٸ� �Ϳ��� ������ ����, ������ �����ѵ��� ���˻�. �ڽ��� ���⸸�� ������ �� ���� �ָ����� �ʴ´�. �̷� �׳࿡�Ե� ģ�� �� ���� �ִٴ� �� ����.";
        }
        if (text.text.Contains("��Ű"))
        {
            UnitText.text = "�����й��ϰ� �� ������ �㼼�� �θ����� ������ �׷��� ���ϴ�. �屺 ������ ���� �����ɷ¸�ŭ�� �����ϴ�. �׸��� �������� �Ϳ���.";
        }
        if (text.text.Contains("����"))
        {
            UnitText.text = "Ÿ���� ������ �������, �پ��� ���� �����ϴ� �Ϳ� �����Ѵ�. ���迡 ��ģ ���� ���⸦ ���̸�, �׳��� ������� �� ���ο� ���ҷ� ���� �� ������ ���Ӿ��� �������� ���� �ֺ������� �׳ฦ ��ġ���̷� �����.";
        }
        if (text.text.Contains("���̸�"))
        {
            UnitText.text = "����� �������� �ź� ķ���� �� ������ �ź�����, ���� ����̸� ��θ� ��ȣ�ϰ��� �ڽ��� �ູ�� ġ�� �ɷ��� Ȱ���ϱ� ���� ���� �ڿ��Դ��Ͽ���. �ɷ��� ������ �پ���� ������ �ڽŰ��� �ټ� �����ѵ��ϴ�.";
        }
        if (text.text.Contains("�׷���"))
        {
            UnitText.text = "��Ű�� ������� �ټ��� �������� �¸��� �̲� ���׶� �屺����, ���� ���̿����� �׳��� ���ں��� ���� ��Ÿ�� ������ ���, �Ǹ� ������ �Ҹ� ������ �Ǹ��� ����. ���ÿ��� �����ϰ� ģ�������� ������ ���� ���� �ٸ�, ����� �������� ��� �巯����.";
        }
        if (text.text.Contains("����"))
        {
            UnitText.text = "�巡���� �������, ������ ���� ���� �����ϰ� �¾ �뺴 ��Ȱ�� �������� �����ؿԴ�. ����� ������ ����������, Į���ʹ� ���� ������ ģ���� ������ �׻� �Բ� ���弭 ������.";
        }
    }
}
