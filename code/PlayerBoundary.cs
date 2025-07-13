using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    private Camera mainCamera;  // 主攝影機
    public float padding = 1f;  // 邊界距離，設置角色距離螢幕邊緣的距離（例如 0.1 是 10% 螢幕範圍）

    void Start()
    {
        // 獲取主攝影機
        mainCamera = Camera.main;
    }

    void Update()
    {
        // 獲取角色的當前位置
        Vector3 playerPosition = transform.position;

        // 取得螢幕邊界的世界座標
        Vector3 screenMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));  // 螢幕左下角
        Vector3 screenMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));  // 螢幕右上角

        // 計算角色的邊界，將角色位置限制在螢幕範圍內
        float clampedX = Mathf.Clamp(playerPosition.x, screenMin.x + padding, screenMax.x - padding);
        float clampedY = Mathf.Clamp(playerPosition.y, screenMin.y + padding, screenMax.y - padding);

        // 更新角色位置
        transform.position = new Vector3(clampedX, clampedY, playerPosition.z);
    }
}