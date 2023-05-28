using UnityEditor;
using UnityEditor.SceneManagement;

namespace _Scripts.Editor
{
    public static class SceneSwitchHelper
    {
        [MenuItem("Scenes/Initial", isValidateFunction: false, priority: 0)]
        public static void SwitchScene_Initial()
        {
            EditorSceneManager.OpenScene("Assets/_GameResources/Scenes/Initial.unity");
        }
        
        [MenuItem("Scenes/Level1", isValidateFunction: false, priority: 0)]
        public static void SwitchScene_Level1()
        {
            EditorSceneManager.OpenScene("Assets/_GameResources/Scenes/Level1.unity");
        }
    }
}
