using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace eProdaja.Database
{
    public partial class eProdajaContext : DbContext
    {
        public eProdajaContext()
        {
        }

        public eProdajaContext(DbContextOptions<eProdajaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dobavljaci> Dobavljacis { get; set; }
        public virtual DbSet<IzlazStavke> IzlazStavkes { get; set; }
        public virtual DbSet<Izlazi> Izlazis { get; set; }
        public virtual DbSet<JediniceMjere> JediniceMjeres { get; set; }
        public virtual DbSet<Korisnici> Korisnicis { get; set; }
        public virtual DbSet<KorisniciUloge> KorisniciUloges { get; set; }
        public virtual DbSet<Kupci> Kupcis { get; set; }
        public virtual DbSet<NarudzbaStavke> NarudzbaStavkes { get; set; }
        public virtual DbSet<Narudzbe> Narudzbes { get; set; }
        public virtual DbSet<Ocjene> Ocjenes { get; set; }
        public virtual DbSet<Proizvodi> Proizvodis { get; set; }
        public virtual DbSet<Skladistum> Skladista { get; set; }
        public virtual DbSet<UlazStavke> UlazStavkes { get; set; }
        public virtual DbSet<Ulazi> Ulazis { get; set; }
        public virtual DbSet<Uloge> Uloges { get; set; }
        public virtual DbSet<VrsteProizvodum> VrsteProizvoda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost, 1434;Initial Catalog=eProdaja; user=sa; Password=QWEasd123!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Dobavljaci>(entity =>
            {
                entity.HasKey(e => e.DobavljacId);

                entity.ToTable("Dobavljaci");

                entity.Property(e => e.DobavljacId).HasColumnName("DobavljacID");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(25);

                entity.Property(e => e.KontaktOsoba).HasMaxLength(100);

                entity.Property(e => e.Napomena).HasMaxLength(500);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Web).HasMaxLength(100);

                entity.Property(e => e.ZiroRacuni).HasMaxLength(255);
            });

            modelBuilder.Entity<IzlazStavke>(entity =>
            {
                entity.HasKey(e => e.IzlazStavkaId);

                entity.ToTable("IzlazStavke");

                entity.Property(e => e.IzlazStavkaId).HasColumnName("IzlazStavkaID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IzlazId).HasColumnName("IzlazID");

                entity.Property(e => e.Popust).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

                entity.HasOne(d => d.Izlaz)
                    .WithMany(p => p.IzlazStavkes)
                    .HasForeignKey(d => d.IzlazId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IzlazStavke_Izlazi");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.IzlazStavkes)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IzlazStavke_Proizvodi");
            });

            modelBuilder.Entity<Izlazi>(entity =>
            {
                entity.HasKey(e => e.IzlazId);

                entity.ToTable("Izlazi");

                entity.Property(e => e.IzlazId).HasColumnName("IzlazID");

                entity.Property(e => e.BrojRacuna)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.IznosBezPdv)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IznosBezPDV");

                entity.Property(e => e.IznosSaPdv)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IznosSaPDV");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.NarudzbaId).HasColumnName("NarudzbaID");

                entity.Property(e => e.SkladisteId).HasColumnName("SkladisteID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Izlazis)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Izlazi_Korisnici");

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.Izlazis)
                    .HasForeignKey(d => d.NarudzbaId)
                    .HasConstraintName("FK_Izlazi_Narudzbe");

                entity.HasOne(d => d.Skladiste)
                    .WithMany(p => p.Izlazis)
                    .HasForeignKey(d => d.SkladisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Izlazi_Skladista");
            });

            modelBuilder.Entity<JediniceMjere>(entity =>
            {
                entity.HasKey(e => e.JedinicaMjereId);

                entity.ToTable("JediniceMjere");

                entity.Property(e => e.JedinicaMjereId).HasColumnName("JedinicaMjereID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Korisnici>(entity =>
            {
                entity.HasKey(e => e.KorisnikId);

                entity.ToTable("Korisnici");

                entity.HasIndex(e => e.Email, "CS_Email")
                    .IsUnique();

                entity.HasIndex(e => e.KorisnickoIme, "CS_KorisnickoIme")
                    .IsUnique();

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Telefon).HasMaxLength(20);
            });

            modelBuilder.Entity<KorisniciUloge>(entity =>
            {
                entity.HasKey(e => e.KorisnikUlogaId);

                entity.ToTable("KorisniciUloge");

                entity.Property(e => e.KorisnikUlogaId).HasColumnName("KorisnikUlogaID");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.KorisniciUloges)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Korisnici");

                entity.HasOne(d => d.Uloga)
                    .WithMany(p => p.KorisniciUloges)
                    .HasForeignKey(d => d.UlogaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KorisniciUloge_Uloge");
            });

            modelBuilder.Entity<Kupci>(entity =>
            {
                entity.HasKey(e => e.KupacId);

                entity.ToTable("Kupci");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.DatumRegistracije).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaHash)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LozinkaSalt)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NarudzbaStavke>(entity =>
            {
                entity.HasKey(e => e.NarudzbaStavkaId);

                entity.ToTable("NarudzbaStavke");

                entity.Property(e => e.NarudzbaStavkaId).HasColumnName("NarudzbaStavkaID");

                entity.Property(e => e.NarudzbaId).HasColumnName("NarudzbaID");

                entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

                entity.HasOne(d => d.Narudzba)
                    .WithMany(p => p.NarudzbaStavkes)
                    .HasForeignKey(d => d.NarudzbaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NarudzbaStavke_Narudzbe");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.NarudzbaStavkes)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NarudzbaStavke_Proizvodi");
            });

            modelBuilder.Entity<Narudzbe>(entity =>
            {
                entity.HasKey(e => e.NarudzbaId);

                entity.ToTable("Narudzbe");

                entity.Property(e => e.NarudzbaId).HasColumnName("NarudzbaID");

                entity.Property(e => e.BrojNarudzbe)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Narudzbes)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Narudzbe_Kupci");
            });

            modelBuilder.Entity<Ocjene>(entity =>
            {
                entity.HasKey(e => e.OcjenaId);

                entity.ToTable("Ocjene");

                entity.Property(e => e.OcjenaId).HasColumnName("OcjenaID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.KupacId).HasColumnName("KupacID");

                entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

                entity.HasOne(d => d.Kupac)
                    .WithMany(p => p.Ocjenes)
                    .HasForeignKey(d => d.KupacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjene_Kupci");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.Ocjenes)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ocjene_Proizvodi");
            });

            modelBuilder.Entity<Proizvodi>(entity =>
            {
                entity.HasKey(e => e.ProizvodId);

                entity.ToTable("Proizvodi");

                entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.JedinicaMjereId).HasColumnName("JedinicaMjereID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Sifra)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.VrstaId).HasColumnName("VrstaID");

                entity.HasOne(d => d.JedinicaMjere)
                    .WithMany(p => p.Proizvodis)
                    .HasForeignKey(d => d.JedinicaMjereId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proizvodi_JediniceMjere");

                entity.HasOne(d => d.Vrsta)
                    .WithMany(p => p.Proizvodis)
                    .HasForeignKey(d => d.VrstaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proizvodi_VrsteProizvoda");
            });

            modelBuilder.Entity<Skladistum>(entity =>
            {
                entity.HasKey(e => e.SkladisteId);

                entity.Property(e => e.SkladisteId).HasColumnName("SkladisteID");

                entity.Property(e => e.Adresa).HasMaxLength(150);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(500);
            });

            modelBuilder.Entity<UlazStavke>(entity =>
            {
                entity.HasKey(e => e.UlazStavkaId);

                entity.ToTable("UlazStavke");

                entity.Property(e => e.UlazStavkaId).HasColumnName("UlazStavkaID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProizvodId).HasColumnName("ProizvodID");

                entity.Property(e => e.UlazId).HasColumnName("UlazID");

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.UlazStavkes)
                    .HasForeignKey(d => d.ProizvodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UlazStavke_Proizvodi");

                entity.HasOne(d => d.Ulaz)
                    .WithMany(p => p.UlazStavkes)
                    .HasForeignKey(d => d.UlazId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UlazStavke_Ulazi");
            });

            modelBuilder.Entity<Ulazi>(entity =>
            {
                entity.HasKey(e => e.UlazId);

                entity.ToTable("Ulazi");

                entity.Property(e => e.UlazId).HasColumnName("UlazID");

                entity.Property(e => e.BrojFakture)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.DobavljacId).HasColumnName("DobavljacID");

                entity.Property(e => e.IznosRacuna).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.KorisnikId).HasColumnName("KorisnikID");

                entity.Property(e => e.Napomena).HasMaxLength(500);

                entity.Property(e => e.Pdv)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("PDV");

                entity.Property(e => e.SkladisteId).HasColumnName("SkladisteID");

                entity.HasOne(d => d.Dobavljac)
                    .WithMany(p => p.Ulazis)
                    .HasForeignKey(d => d.DobavljacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulazi_Dobavljaci");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Ulazis)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulazi_Korisnici");

                entity.HasOne(d => d.Skladiste)
                    .WithMany(p => p.Ulazis)
                    .HasForeignKey(d => d.SkladisteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ulazi_Skladista");
            });

            modelBuilder.Entity<Uloge>(entity =>
            {
                entity.HasKey(e => e.UlogaId);

                entity.ToTable("Uloge");

                entity.Property(e => e.UlogaId).HasColumnName("UlogaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(200);
            });

            modelBuilder.Entity<VrsteProizvodum>(entity =>
            {
                entity.HasKey(e => e.VrstaId);

                entity.Property(e => e.VrstaId).HasColumnName("VrstaID");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VrsteProizvodum>().HasData(new VrsteProizvodum { VrstaId = 20, Naziv = "Prehrambeni"});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
