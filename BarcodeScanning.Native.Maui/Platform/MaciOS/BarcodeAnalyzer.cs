﻿using AVFoundation;
using CoreMedia;
using System.Diagnostics;

namespace BarcodeScanning;

internal class BarcodeAnalyzer : AVCaptureVideoDataOutputSampleBufferDelegate
{
    private readonly CameraManager _cameraManager;

    internal BarcodeAnalyzer(CameraManager cameraManager)
    {
        _cameraManager = cameraManager;
    }

    public override void DidOutputSampleBuffer(AVCaptureOutput captureOutput, CMSampleBuffer sampleBuffer, AVCaptureConnection connection)
    {
        try
        {
            if (sampleBuffer is not null)
            {
                if (_cameraManager.CaptureNextFrame)
                    _cameraManager.CaptureImage(sampleBuffer);
                else
                    _cameraManager.PerformBarcodeDetection(sampleBuffer);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            try
            {
                sampleBuffer?.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MainThread.BeginInvokeOnMainThread(() => _cameraManager?.Start());
            }
        }
    }
}
