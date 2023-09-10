using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Exam.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Exam.Infrastructure.Data.Context;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	private readonly IConfiguration _configuration;
	public ApplicationDbContext(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
		: base(options)
	{
		_configuration = configuration;
	}

	public DbSet<Teacher> Teachers { get; set; }
	public DbSet<Student> Students { get; set; }
	public DbSet<Examination> Examinations { get; set; }
	public DbSet<Subject> Subjects { get; set; }
	public DbSet<Question> Questions { get; set; }
	public DbSet<StudentAnswer> StudentAnswers { get; set; }
	public DbSet<Admin> Admins { get; set; }
	public DbSet<TeacherSubject> TeacherSubjects { get; set; }
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		// Configure the table name for ApplicationUser
		builder.Entity<ApplicationUser>().ToTable("ApplicationUser");
	}
}
