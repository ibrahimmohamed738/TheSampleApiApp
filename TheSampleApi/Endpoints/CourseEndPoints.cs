using TheSampleApi.Data;

namespace TheSampleApi.Endpoints
{
    public static class CourseEndPoints
    {
        public static void AddCourseEndPoints(this WebApplication app)
        {
            app.MapGet("/courses", LoadAllCoursesAsync);
            app.MapGet("/courses/{id}", LoadCourseByIdAsync);
        }

        private static async Task<IResult> LoadAllCoursesAsync(
            CourseData data,
            string? courseType,
            string? search,
            int? delay)
        {
            var output = data.Courses;

            if (string.IsNullOrWhiteSpace(courseType) == false)
            {
                output.RemoveAll(x => string.Compare(
                    x.CourseType,
                    courseType,
                    StringComparison.OrdinalIgnoreCase) != 0);
            }


            if (string.IsNullOrWhiteSpace(search) == false)
            {
                output.RemoveAll(x => !x.CourseName.Contains(search, StringComparison.OrdinalIgnoreCase) &&
                !x.ShortDescription.Contains(search, StringComparison.OrdinalIgnoreCase));
            }

            if (delay is not null)
            {
                // Max delay of 5 minutes (300,000 milliseconds)
                if (delay > 300000)
                {
                    delay = 300000;
                }

                await Task.Delay((int)delay);
            }
            return Results.Ok(output);
        }

        private static async Task<IResult> LoadCourseByIdAsync(CourseData data, int id, int? delay)
        {
            var output = data.Courses.SingleOrDefault(x => x.Id == id);

            if (delay is not null)
            {
                // Max delay of 5 minutes (300,000 milliseconds)
                if (delay > 300000)
                {
                    delay = 300000;
                }

                await Task.Delay((int)delay);
            }

            if (output is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(output);
        }
    }
}
