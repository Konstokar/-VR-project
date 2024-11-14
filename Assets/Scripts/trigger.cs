using UnityEngine;

public class trigger : MonoBehaviour
{
    public int clutterLevel = 0; // ��������� ������� ��������������
    public int clutterIncrement = 1; // �� ������� ������������� ������� ��� ���������� ���������
    public float checkInterval = 1f; // �������� �������� (� ��������)

    private bool hasItemInCollider = false; // ����, ��������� �� ������� � ����������

    void Start()
    {
        // ��������� �������� �� ���������� ��������� � ��������� checkInterval
        InvokeRepeating("CheckForClutter", checkInterval, checkInterval);
    }

    void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������ ���, ������� �� ����������� (��������, �� ����)
        if (other.CompareTag("TrackedItem"))
        {
            hasItemInCollider = true; // ������� � ����������
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TrackedItem"))
        {
            hasItemInCollider = false; // ������� ������� ���������
        }
    }

    void CheckForClutter()
    {
        // ���� ������� �����������, ����������� ������� ��������������
        if (!hasItemInCollider)
        {
            clutterLevel += clutterIncrement;
            Debug.Log("������� �������������� ��������: " + clutterLevel);
        }
    }
}