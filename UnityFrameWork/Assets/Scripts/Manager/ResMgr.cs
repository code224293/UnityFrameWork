using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.AddressableAssets;

public class ResMgr : UnitySingleton<ResMgr>
{
    string rootpath = "Assets/AssetPackage/";
    // ��Դ���ػص�
    public delegate void LoadAssetCallback<T>(T asset) where T : Object;

    /// <summary>
    /// �첽������Դ���༭����AssetDatabase������ʱ��Addressables��
    /// </summary>
    /// <typeparam name="T">��Դ����</typeparam>
    /// <param name="path">��Դ·��</param>
    /// <param name="callback">������ɻص�</param>
    public void LoadAssetAsync<T>(string path, LoadAssetCallback<T> callback) where T : Object
    {
#if UNITY_EDITOR
        //�༭��ʹ��AssetDatabase����
        string fullPath = rootpath + path;
        T asset = AssetDatabase.LoadAssetAtPath<T>(fullPath);
        callback?.Invoke(asset);
        return;
#else
        // ����ʱʹ��Addressables����
        string fullPath = rootpath + path;
        Addressables.LoadAssetAsync<T>(fullPath).Completed += handle =>
        {
            if (handle.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
            {
                callback?.Invoke(handle.Result);
            }
            else
            {
                Debug.LogError($"Failed to load asset at path: {fullPath}");
                callback?.Invoke(null);
            }
        };
#endif
    }

    /// <summary>
    /// �ͷ���Դ
    /// </summary>
    /// <param name="asset">Ҫ�ͷŵ���Դ</param>
    public void ReleaseAsset(Object asset)
    {
#if UNITY_EDITOR
        // �༭��ģʽ�²���Ҫ�ͷ�
        if (!Application.isPlaying)
            return;
#endif
        Addressables.Release(asset);
    }

    /// <summary>
    /// �ͷ�������Դ
    /// </summary>
    public void ReleaseAll()
    {
#if UNITY_EDITOR
        // �༭��ģʽ�²���Ҫ�ͷ�
        if (!Application.isPlaying)
            return;
#endif
        // Addressables.ReleaseAll();
    }
}