using UnityEngine;

/// <summary>
/// �̱��� ����. Scene �̵� �� �Բ� �̵��ϴ� ����� ���Ե��� ����. �ʿ��� ��� Awake�� �ּ�ó�� �� ������ �����Ͽ� override�ϴ� ������� ��� �ٶ�.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Singleton<T> : MonoBehaviour where T : Component
{
    // �ڱ� �ڽ��� �ν��Ͻ�(��ũ��Ʈor������Ʈ)�� ������ �����ϸ� �����ǰų� �������� �ʵ��� ����.
    protected static T m_instance;
    public static T I
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<T>();

                if (m_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    m_instance = obj.AddComponent<T>();
                }
            }
            return m_instance;
        }
    }

    // �̱������� �����Ǵ� ������Ʈ���� �߿��ϹǷ� ���� Ȥ�� �����ÿ� �α� ���.

    public virtual void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this as T;
            //DontDestroyOnLoad(this.gameObject);

            Debug.Log((string)this.name + " ����");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        Debug.Log((string)this.name + " ����");
    }
}