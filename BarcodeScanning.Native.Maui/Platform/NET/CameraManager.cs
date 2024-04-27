namespace BarcodeScanning;

internal class CameraManager : IDisposable
{
    internal BarcodeView BarcodeView { get; set; }
    internal void UpdateCamera() { }
    internal void UpdateResolution() { }
    internal void UpdateAnalyzer() { }
    internal void UpdateTorch() { }
    internal void UpdateZoomFactor() { }
    internal void HandleCameraEnabled() { }
    internal void HandleAimMode() { }
    internal void HandleTapToFocus() { }

    public void Dispose() { }
}