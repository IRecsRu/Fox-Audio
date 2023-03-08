using FoxAudioSystem.Scripts;
using FoxAudioSystem.Scripts.PlayersFolder;
using UnityEditor;
using UnityEngine.UIElements;

namespace FoxAudioSystem.EditorFolder.RandomAudioControls
{
  [CustomEditor(typeof(RandomAudioPlayer))]
  public class RandomAudioControls : UnityEditor.Editor
  {
    private VisualElement rootElement;
    private UnityEditor.Editor editor;

    public void OnEnable()
    {
      rootElement = new VisualElement();

      var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(Constants.AudioPaths.EditorPath +"/RandomAudioControls/RandomAudioControls.uss");
      rootElement.styleSheets.Add(styleSheet);
    }

    public override VisualElement CreateInspectorGUI()
    {
      rootElement.Clear();

      UnityEngine.Object.DestroyImmediate(editor);
      editor = UnityEditor.Editor.CreateEditor(this);
      IMGUIContainer container = new IMGUIContainer(() =>
      {
        if (target)
        {
          OnInspectorGUI();
        }
      });
      rootElement.Add(container);

      var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>(Constants.AudioPaths.EditorPath +"/RandomAudioControls/RandomAudioControls.uxml");
      visualTree.CloneTree(rootElement);

      RandomAudioPlayer randomAudioPlayerTarget = (RandomAudioPlayer)target;

      Button generateAudioSourceButton = rootElement.Q<Button>("generate-audio-source");
      generateAudioSourceButton.clicked += () =>
      {
        randomAudioPlayerTarget.GenerateAudioSource();
      };

      Button playButton = rootElement.Q<Button>("play");
      playButton.clicked += () =>
      {
        randomAudioPlayerTarget.PlayRandom();
      };

      return rootElement;

    }
  }
}