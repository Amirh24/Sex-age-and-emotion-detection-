// 
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.
// 
// Microsoft Cognitive Services: http://www.microsoft.com/cognitive
// 
// Microsoft Cognitive Services Github:
// https://github.com/Microsoft/Cognitive
// 
// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// MIT License:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Emotion.Contract;
using Microsoft.ProjectOxford.Face.Contract;

namespace LiveCameraSample
{
    internal class Aggregation
    {
        /*
        // NOT USED 
        public static Tuple<string, float> GetDominantEmotion(Scores scores)
        {
            float maxScore = 0;
            string dominant = "";
            if (scores.Anger > maxScore) { maxScore = scores.Anger; dominant = "כעס / Anger"; }
            if (scores.Contempt > maxScore) { maxScore = scores.Contempt; dominant = "בוז / Contempt"; }
            if (scores.Disgust > maxScore) { maxScore = scores.Disgust; dominant = "גועל / Disgust"; }
            if (scores.Fear > maxScore) { maxScore = scores.Fear; dominant = "פחד / Fear"; }
            if (scores.Happiness > maxScore) { maxScore = scores.Happiness; dominant = "שמחה / Happiness"; }
            if (scores.Neutral > maxScore) { maxScore = scores.Neutral; dominant = "טבעי / Neutral"; }
            if (scores.Sadness > maxScore) { maxScore = scores.Sadness; dominant = "עצב / Sadness"; }
            if (scores.Surprise > maxScore) { maxScore = scores.Surprise; dominant = "הפתעה / Surprise"; }
            return new Tuple<string, float>(dominant, maxScore * 100);
        }

        // NOT USED 
        public static string SummarizeEmotion(Scores scores)
        {
            var bestEmotion = Aggregation.GetDominantEmotion(scores);
            return string.Format("{0}: {1:N1}%", bestEmotion.Item1, bestEmotion.Item2);
        }
        */

        public static string SummarizeFaceAttributes(FaceAttributes attr)
        {
            List<string> attrs = new List<string>();
            string text = "";
            
            if (attr.Gender != null)
            {
                text = ("" + attr.Gender).Equals("male") ?  "Male@" : "Female@";
                attrs.Add(text);
            }
            if (attr.Age > 0) text += "Age: ~" + attr.Age.ToString() + "@";


            text += SummarizeEmotionFaceAPI(attr);

            text = text.Replace("@", System.Environment.NewLine);


            return text;
        }

        private static Tuple<string, float> GetDominantEmotionFaceAPI(FaceAttributes attr)
        {
            float maxScore = 0;
            string dominant = "";
            if (attr.Emotion.Anger > maxScore) { maxScore = attr.Emotion.Anger; dominant = "Anger"; }
            if (attr.Emotion.Contempt > maxScore) { maxScore = attr.Emotion.Contempt; dominant = "Contempt"; }
            if (attr.Emotion.Disgust > maxScore) { maxScore = attr.Emotion.Disgust; dominant = "Disgust"; }
            if (attr.Emotion.Fear > maxScore) { maxScore = attr.Emotion.Fear; dominant = "Fear"; }
            if (attr.Emotion.Happiness > maxScore) { maxScore = attr.Emotion.Happiness; dominant = "Happiness"; }
            if (attr.Emotion.Neutral > maxScore) { maxScore = attr.Emotion.Neutral; dominant = "Neutral"; }
            if (attr.Emotion.Sadness > maxScore) { maxScore = attr.Emotion.Sadness; dominant = "Sadness"; }
            if (attr.Emotion.Surprise > maxScore) { maxScore =attr.Emotion.Surprise; dominant = "Surprise"; }
            Console.WriteLine(attr.Emotion.Anger);
            return new Tuple<string, float>(dominant, maxScore * 100);

        }

        private static string SummarizeEmotionFaceAPI(FaceAttributes attr)
        {
            var bestEmotion = Aggregation.GetDominantEmotionFaceAPI(attr);
            return string.Format("{0}: {1:N1}%", bestEmotion.Item1, bestEmotion.Item2);
        }
   
    } 
}
