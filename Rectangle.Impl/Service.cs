using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangle.Impl
{
	public static class Service
	{
        

        /// <summary>
        /// See TODO.txt file for task details.
        /// Do not change contracts: input and output arguments, method name and access modifiers
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>

        public static Rectangle FindRectangle(List<Point> points)
		{
			  Validate(points);
		
			Random random = new Random();
			Rectangle rectangle = new Rectangle();
			points.OrderByDescending(y => y.Y);
			points.RemoveAt(0);
            
			rectangle.X = random.Next(0,10);
			rectangle.Y = random.Next(0,10);
			rectangle.Width = rectangle.X;

			rectangle.Height = rectangle.Y;

            

			return rectangle;
		}
		public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable == null)
			{
				return true;
			}
			/* If this is a list, use the Count property for efficiency. 
			 * The Count property is O(1) while IEnumerable.Count() is O(N). */
			var collection = enumerable as ICollection<T>;
			if (collection != null)
			{
				return collection.Count < 1;
			}
			return !enumerable.Any();
		}

		public static void Validate(List<Point> points)
		{
			Exception ex = new Exception("the input list is invalid");

			if (points.IsNullOrEmpty())
			{
				throw ex;
			}
			else if (points.Count < 2)
			{
				throw ex;
			}
			else
			{
				var valueX = 0;
				var valueY = 0;
				foreach (var point in points)
				{
					if (valueX == point.X)
					{
						if (valueY == point.Y)
						{
							throw ex;
						}
					}
					else
					{
						valueX = point.X;
						valueY = point.Y;
					}
				}
			}
		}

    }
}
