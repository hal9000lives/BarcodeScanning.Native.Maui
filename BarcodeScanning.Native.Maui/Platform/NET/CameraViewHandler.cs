namespace BarcodeScanning;

public partial class CameraViewHandler
{
    protected override BarcodeView CreatePlatformView()
    {
        _cameraManager = new CameraManager();
        return _cameraManager.BarcodeView;
    }
}
