using System;
using KontrolSystem.KSP.Runtime.KSPConsole;
using KontrolSystem.TO2.Binding;
using KSP.Game;
using KSP.Map;
using KSP.Sim;
using Shapes;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace KontrolSystem.KSP.Runtime.KSPDebug {
    public partial class KSPDebugModule {
        [KSClass("DebugVector",
            Description = "Represents a debugging vector in the current scene."
        )]
        public class VectorRenderer : IMarker {
            [KSField(Description = "The color of the debugging vector")]
            public KSPConsoleModule.RgbaColor Color { get; set; }

            [KSField] public double Scale { get; set; }

            [KSField(Description = "The width of the debugging vector")]
            public double Width { get; set; }

            [KSField(Description = "Controls if an arrow should be drawn at the end.")]
            public bool Pointy { get; set; }

            private bool enable;

            private Func<Position> startProvider;
            private Func<Position> endProvider;
            private Func<Vector> vectorProvider;

            private string labelStr;

            private Vector3 labelLocation;

            private VectorRenderer(Func<Position> startProvider, Func<Position> endProvider, Func<Vector> vectorProvider,
                KSPConsoleModule.RgbaColor color, string label, double width, bool pointy) {
                this.startProvider = startProvider;
                this.endProvider = endProvider;
                this.vectorProvider = vectorProvider;
                Color = color;
                Scale = 1.0;
                Width = width;
                Pointy = pointy;
                labelStr = label;
            }

            public VectorRenderer(Func<Position> startProvider, Func<Position> endProvider,
                KSPConsoleModule.RgbaColor color, string label, double width, bool pointy) : this(startProvider, endProvider, null, color, label, width, pointy) {
            }

            public VectorRenderer(Func<Position> startProvider, Func<Vector> vectorProvider,
                KSPConsoleModule.RgbaColor color, string label, double width, bool pointy) : this(startProvider, null, vectorProvider, color, label, width, pointy) {
            }

            [KSField(Description = "Controls if the debug-vector is currently visible (initially `true`)")]
            public bool Visible {
                get => enable;
                set => enable = value;
            }

            [KSMethod]
            public void Remove() => KSPContext.CurrentContext.RemoveMarker(this);

            public void OnUpdate() {
            }

            public void OnRender() {
            }

            public void OnDrawShapes(Camera cam) {
                if (!enable) return;
                using (Draw.Command(cam, CameraEvent.AfterForwardAlpha)) {
                    Draw.ResetAllDrawStates();
                    Draw.BlendMode = ShapesBlendMode.Opaque;

                    Draw.ConeSizeSpace = ThicknessSpace.Pixels;
                    Draw.LineThicknessSpace = ThicknessSpace.Pixels;
                    Draw.LineThickness = (float)Width;
                    Draw.LineGeometry = LineGeometry.Volumetric3D;

                    Position start = startProvider();
                    Position end = endProvider?.Invoke() ?? start + vectorProvider();
                    Vector3d startLocal;
                    Vector3d vectorLocal;
                    double mapWidthMult = 1.0;

                    if (KSPContext.CurrentContext.Game.Map.TryGetMapCore(out MapCore mapCore) && mapCore.IsEnabled) {
                        var space = mapCore.map3D.GetSpaceProvider();

                        startLocal = space.TranslateSimPositionToMapPosition(start);
                        vectorLocal = space.TranslateSimPositionToMapPosition(end) - startLocal;
                        mapWidthMult = 1500 / space.Map3DScaleInv;
                    } else {
                        var frame = KSPContext.CurrentContext.ActiveVessel.transform?.coordinateSystem;
                        startLocal = frame.ToLocalPosition(start);
                        vectorLocal = frame.ToLocalPosition(end) - startLocal;
                    }

                    Draw.FontSize = (float)(12 * mapWidthMult);

                    Draw.Line(startLocal, startLocal + vectorLocal, Color.Color);
                    if (Pointy)
                        Draw.Cone(startLocal + vectorLocal, vectorLocal.normalized, (float)(Width * 2),
                            (float)(Width * 2), false, Color.Color);
                    Draw.Text(startLocal + 0.5 * vectorLocal, cam.transform.rotation, labelStr, Color.Color);
                }
            }

            [KSField(Description = "The current starting position of the debugging vector.")]
            public Position Start {
                get => startProvider();
                set => startProvider = () => value;
            }

            [KSField(Description = "The current end position of the debugging vector.")]
            public Position End {
                get => endProvider?.Invoke() ?? startProvider() + vectorProvider();
                set {
                    endProvider = () => value;
                    vectorProvider = null;
                }
            }

            [KSMethod(Description = "Change the function providing the start position of the debug vector.")]
            public void SetStartProvider(Func<Position> startProvider) {
                this.startProvider = startProvider;
            }

            [KSMethod(Description = "Change the function providing the end position of the debug vector.")]
            public void SetEndProvider(Func<Position> endProvider) {
                this.endProvider = endProvider;
                this.vectorProvider = null;
            }

            [KSMethod(Description = "Change the function providing the vector/direction of the debug vector.")]
            public void SetVectorProvider(Func<Vector> vectorProvider) {
                this.endProvider = null;
                this.vectorProvider = vectorProvider;
            }

            private void RenderPointCoords() {
            }            

            public void RenderColor() {
            }

            public void RenderValues() {
                RenderPointCoords();
                RenderColor();
                LabelPlacement();
            }

            private void LabelPlacement() {

            }
        }
    }
}
