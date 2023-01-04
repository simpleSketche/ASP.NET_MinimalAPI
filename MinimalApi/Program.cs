using GraphData;

var builder = WebApplication.CreateBuilder(args);


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

app.MapGet("/api/GetNodes", () => GraphDataHandler.Instance.SerializeNodes());

app.MapGet("/api/GetEdges", () => GraphDataHandler.Instance.SerializeEdges());

app.Run();