using JsonSubTypes;
using PolymorphismApi.Models;

namespace PolymorphismApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                //Register the subtypes of the Device (Phone and Laptop)
                //and define the device Discriminator
                options.SerializerSettings.Converters.Add(
                    JsonSubtypesConverterBuilder
                    .Of(typeof(BaseClass), "Type")
                    .RegisterSubtype<FirstSubClass>(DerivedClassEnum.First)
                    .RegisterSubtype<SecondSubClass>(DerivedClassEnum.Second)
                    .SerializeDiscriminatorProperty()
                    .Build()
                );

            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}