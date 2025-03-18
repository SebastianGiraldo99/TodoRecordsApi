using Microsoft.EntityFrameworkCore;
using TodoRecords.Domain.Models;

namespace TodoRecords.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {

        }

        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoModel>().HasKey(t => t.IdTodo);
            modelBuilder.Entity<TodoModel>().HasData(
                new TodoModel { IdTodo = 1, Title = "Completar documentación", Description = "Finalizar la documentación del proyecto.", Status = "En progreso", CreateAt = DateTime.UtcNow, UpdateAt = null, DeleteAt = null, IsDeleted = false },
                new TodoModel { IdTodo = 2, Title = "Revisión de código", Description = "Revisar el código de los nuevos commits.", Status = "Pendiente", CreateAt = DateTime.UtcNow.AddDays(-2), UpdateAt = DateTime.UtcNow.AddDays(-1), DeleteAt = null, IsDeleted = false },
                new TodoModel { IdTodo = 3, Title = "Implementar autenticación", Description = "Agregar autenticación JWT al sistema.", Status = "Completado", CreateAt = DateTime.UtcNow.AddDays(-10), UpdateAt = DateTime.UtcNow.AddDays(-5), DeleteAt = null, IsDeleted = false },
                new TodoModel { IdTodo = 4, Title = "Optimizar consultas SQL", Description = "Mejorar el rendimiento de las consultas en la API.", Status = "En progreso", CreateAt = DateTime.UtcNow.AddDays(-3), UpdateAt = null, DeleteAt = null, IsDeleted = false },
                new TodoModel { IdTodo = 5, Title = "Eliminar datos obsoletos", Description = "Borrar registros antiguos de la base de datos.", Status = "Cancelado", CreateAt = DateTime.UtcNow.AddDays(-20), UpdateAt = DateTime.UtcNow.AddDays(-15), DeleteAt = DateTime.UtcNow.AddDays(-10), IsDeleted = true }
            );
        }


    }


}
