using UnityEngine;

public class FindInvalidObjects : MonoBehaviour
{
    void Start()
    {
        // 找到場景中所有的 GameObject
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.transform != null)
            {
                // 取得 Transform 資訊
                Vector3 pos = obj.transform.position;
                Vector3 scale = obj.transform.localScale;

                // 檢查 Position 是否有 NaN 或 Infinity
                if (float.IsNaN(pos.x) || float.IsNaN(pos.y) || float.IsNaN(pos.z) ||
                    float.IsInfinity(pos.x) || float.IsInfinity(pos.y) || float.IsInfinity(pos.z))
                {
                    Debug.LogError("❌ 無效的 Position: " + obj.name, obj);
                }

                // 檢查 Scale 是否過小（0）或過大
                if (scale.x == 0 || scale.y == 0 || scale.z == 0)
                {
                    Debug.LogWarning("⚠️ Scale = 0 可能導致問題: " + obj.name, obj);
                }
            }
        }
    }
}
