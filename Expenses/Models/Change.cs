using System;

namespace Expenses.Models
{
	public class Change
	{
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public decimal Value { get; set; }

        

        public Change()
		{
			Date = DateTime.Now;
		}
		public override string ToString()
		{
			return String.Format("{0} {1} {2}", Name, Value, Date.ToString("d"));
		}
	}

}