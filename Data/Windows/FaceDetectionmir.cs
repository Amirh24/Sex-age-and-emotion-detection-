using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace faceDetection
{
    class Program
    {
        static void Main(string[] args)
        {

            CvCapture camera = new CvCapture(0);
            CvWindow win = new CvWindow();

            CvHaarClassifierCascade face_classifier = CvHaarClassifierCascade.FromFile("haarcascade_frontalface_alt.xml");
            CvMemStorage storage = new CvMemStorage();

            while (CvWindow.WaitKey(10) < 0)
            {
                using (IplImage img = camera.QueryFrame())
                {
                    storage.Clear();
                    CvSeq<CvAvgComp> faces = Cv.HaarDetectObjects(img, face_classifier, storage, 1.5, 1, HaarDetectionType.ScaleImage,new CvSize(50,50));
                    for (int i = 0; i < faces.Total; i++)
                    {
                        img.Rectangle(faces[i].Value.Rect, CvColor.Red);
                    }

                    win.Image = img;
                }
            }
        }
    }
}