// Copyright(c) 2023 Joshua Bounds (Sidega)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to
// the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR
// IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.


using UnityEngine;
using UnityEditor;

public class RenameAnimationPaths : EditorWindow
{
    /*
    Allows for quickly renaming multiple curve bindings in a single animation clip at once.
    */

    [MenuItem("Tools/Joshua/Rename Animation Paths")]
    public static void OpenWindow()
    {
        var window = GetWindow<RenameAnimationPaths>();
        window.titleContent = new GUIContent("Rename Animation Paths");
    }    

    AnimationClip animationClip;
    private string searchPattern = "";
    private string subString = "";
    private GUIContent outputLog = new GUIContent("Waiting...");
    private string outputText = "Waiting...";

    private void OnGUI()
    {
        animationClip = EditorGUILayout.ObjectField("Target Clip", animationClip, typeof(AnimationClip), true) as AnimationClip;
        searchPattern = EditorGUILayout.TextField("Search Pattern", searchPattern);
        subString = EditorGUILayout.TextField("Sub String", subString);
        bool execute = GUILayout.Button("Rename");

        if (animationClip != null && searchPattern.Length > 0)
        {
            outputText = "Processing output...";
            EditorCurveBinding[] curveBindings = AnimationUtility.GetCurveBindings(animationClip);
            for (int i = 0; i < curveBindings.Length; i++)
            {
                EditorCurveBinding curveBinding = curveBindings[i];

                string curveBindingPath = curveBinding.path.Replace(searchPattern, subString);                
                outputText += System.Environment.NewLine + curveBinding.path + " -> " + curveBindingPath;

                if (execute)
                {
                    EditorCurveBinding newCurveBinding = new EditorCurveBinding();
                    newCurveBinding.path = curveBindingPath;
                    newCurveBinding.propertyName = curveBinding.propertyName;
                    newCurveBinding.type = curveBinding.type;

                    AnimationCurve editorCurve = AnimationUtility.GetEditorCurve(animationClip, curveBinding);
                    AnimationUtility.SetEditorCurve(animationClip, newCurveBinding, editorCurve);

                    AnimationUtility.SetEditorCurve(animationClip, curveBinding, null);
                }
            }
        }

        outputLog.text = outputText;
        EditorStyles.label.wordWrap = true;
        GUILayout.Label(outputLog);
    }
}
