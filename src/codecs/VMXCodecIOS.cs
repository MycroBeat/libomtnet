﻿/*
* MIT License
*
* Copyright (c) 2025 Open Media Transport Contributors
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace libomtnet.codecs
{
    internal class VMXCodecIOS : IVMXCodec
    {
        public float VMX_CalculatePSNR(byte[] image1, byte[] image2, int stride, int bytesPerPixel, OMTSize sz)
        {
            return VMXUnmanagedIOS.VMX_CalculatePSNR(image1, image2, stride, bytesPerPixel, sz);
        }

        public IntPtr VMX_Create(OMTSize dimensions, VMXProfile profile, VMXColorSpace colorSpace)
        {
            return VMXUnmanagedIOS.VMX_Create(dimensions, profile, colorSpace);
        }

        public int VMX_DecodeBGRA(IntPtr Instance, byte[] dst, int stride)
        {
            return VMXUnmanagedIOS.VMX_DecodeBGRA(Instance, dst, stride);
        }

        public int VMX_DecodeBGRX(IntPtr Instance, byte[] dst, int stride)
        {
            return VMXUnmanagedIOS.VMX_DecodeBGRX(Instance, dst, stride);
        }

        public int VMX_DecodePreviewBGRA(IntPtr Instance, byte[] dst, int stride)
        {
            return VMXUnmanagedIOS.VMX_DecodePreviewBGRA(Instance, dst, stride);
        }

        public int VMX_DecodePreviewBGRX(IntPtr Instance, byte[] dst, int stride)
        {
            return VMXUnmanagedIOS.VMX_DecodePreviewBGRX(Instance, dst, stride);
        }

        public int VMX_DecodePreviewUYVY(IntPtr Instance, byte[] dst, int stride)
        {
            return VMXUnmanagedIOS.VMX_DecodePreviewUYVY(Instance, dst, stride);
        }

        public int VMX_DecodePreviewYUY2(IntPtr Instance, byte[] dst, int stride)
        {
            return VMXUnmanagedIOS.VMX_DecodePreviewYUY2(Instance, dst, stride);
        }

        public int VMX_DecodeUYVY(IntPtr Instance, byte[] dst, int stride)
        {
            return VMXUnmanagedIOS.VMX_DecodeUYVY(Instance, dst, stride);
        }

        public int VMX_DecodeYUY2(IntPtr Instance, byte[] dst, int stride)
        {
            return VMXUnmanagedIOS.VMX_DecodeYUY2(Instance, dst, stride);
        }

        public void VMX_Destroy(IntPtr instance)
        {
            VMXUnmanagedIOS.VMX_Destroy(instance);
        }

        public int VMX_EncodeBGRA(IntPtr Instance, IntPtr src, int stride, int interlaced)
        {
            return VMXUnmanagedIOS.VMX_EncodeBGRA(Instance, src, stride, interlaced);
        }

        public int VMX_EncodeBGRX(IntPtr Instance, IntPtr src, int stride, int interlaced)
        {
            return VMXUnmanagedIOS.VMX_EncodeBGRX(Instance, src, stride, interlaced);
        }

        public int VMX_EncodeNV12(IntPtr Instance, IntPtr srcY, int strideY, IntPtr srcUV, int strideUV, int interlaced)
        {
            return VMXUnmanagedIOS.VMX_EncodeNV12(Instance, srcY, strideY, srcUV, strideUV, interlaced);
        }

        public int VMX_EncodeUYVY(IntPtr Instance, IntPtr src, int stride, int interlaced)
        {
            return VMXUnmanagedIOS.VMX_EncodeUYVY(Instance, src, stride, interlaced);
        }

        public int VMX_EncodeYUY2(IntPtr Instance, IntPtr src, int stride, int interlaced)
        {
            return VMXUnmanagedIOS.VMX_EncodeYUY2(Instance, src, stride, interlaced);
        }

        public int VMX_EncodeYV12(IntPtr Instance, IntPtr srcY, int strideY, IntPtr srcU, int strideU, IntPtr srcV, int strideV, int interlaced)
        {
            return VMXUnmanagedIOS.VMX_EncodeYV12(Instance, srcY, strideY, srcU, strideU, srcV, strideV, interlaced);
        }

        public int VMX_GetEncodedPreviewLength(IntPtr Instance)
        {
            return VMXUnmanagedIOS.VMX_GetEncodedPreviewLength(Instance);
        }

        public int VMX_GetThreads(IntPtr instance)
        {
            return VMXUnmanagedIOS.VMX_GetThreads(instance);
        }

        public int VMX_LoadFrom(IntPtr instance, byte[] data, int dataLen)
        {
            return VMXUnmanagedIOS.VMX_LoadFrom(instance, data, dataLen);
        }

        public int VMX_SaveTo(IntPtr instance, byte[] data, int maxLen)
        {
            return VMXUnmanagedIOS.VMX_SaveTo(instance, data, maxLen);
        }

        public void VMX_SetQuality(IntPtr instance, int q)
        {
            VMXUnmanagedIOS.VMX_SetQuality(instance, q);
        }

        public void VMX_SetThreads(IntPtr instance, int t)
        {
            VMXUnmanagedIOS.VMX_SetThreads(instance, t);
        }

    }
}
