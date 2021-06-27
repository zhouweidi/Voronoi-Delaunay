using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voronoi_Delaunay
{
	public struct Line
	{
		private float m_a;
		private float m_b;
		private float m_c;

		public Line(float a, float b, float c)
		{
			m_a = a;
			m_b = b;
			m_c = c;
		}

		public Line(float x0, float y0, float x1, float y1)
		{
			m_a = a;
			m_b = b;
			m_c = c;
		}

		public static bool ArePerpendicular(Line lineOne, Line lineTwo) =>
			(lineOne.IsHorizontal && lineTwo.IsVertical) || (lineTwo.IsHorizontal && lineOne.IsVertical) || (lineOne.getSlope() * lineTwo.getSlope() == -1);

		public static bool AreParallel(Line lineOne, Line lineTwo) =>
			(lineOne.IsVertical && lineTwo.IsVertical) || (lineOne.getSlope() == lineTwo.getSlope());

		public enum POIResult
		{
			Single, Infinite, None
		}

		public static Point? PointOfJntersection(Line l0, Line l1, out POIResult result)
		{
			if (l0 == l1)
			{
				result = POIResult.Infinite;
				return null;
			}

			if (AreParrellel(l0, l1))
			{
				result = POIResult.None;
				return null;
			}
		
			result = POIResult.Single;
			if (AreParrellel(l0, l1))
			{
				return null;
			}
		}

		public bool IsVertical => m_a != 0 && m_b == 0;
		public bool IsHorizontal => m_a == 0 && m_b != 0;
		public float? Slope
		{
			get
			{
				if (IsVertical)
					return null;

				if (IsHorizontal)
					return 0;

				return -m_a / m_b;
			}
		}

	}
}
