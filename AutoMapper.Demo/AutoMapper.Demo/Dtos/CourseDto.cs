namespace AutoMapper.Demo.Dtos
{
	public class CourseDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public double Price { get; set; }
		//public bool IsFree => Price == 0;
		public bool IsFree { get; set; }
	}
}
