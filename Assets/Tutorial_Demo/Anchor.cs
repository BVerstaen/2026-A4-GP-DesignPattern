using UnityEngine;

class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
}

[CreateAssetMenu(fileName = "TestScriptable", menuName = "Stupid/TestScriptable")]
public class Anchor<T> : ScriptableObject
{
    T _ref;
    public T Ref => _ref;

    public void SetRef(T reference) => _ref = reference;
}
