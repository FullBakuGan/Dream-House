using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dream_House.Migrations
{
    /// <inheritdoc />
    public partial class migr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор города (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название города (например, \"Москва\")")
                },
                constraints: table =>
                {
                    table.PrimaryKey("city_pkey", x => x.id);
                },
                comment: "Хранит информацию о городах");

            migrationBuilder.CreateTable(
                name: "city_district",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор городского района (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    city_district_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название городского района (например, \"Тверской\")")
                },
                constraints: table =>
                {
                    table.PrimaryKey("city_district_pkey", x => x.id);
                },
                comment: "Хранит информацию о городских районах (например, подрайоны внутри города)");

            migrationBuilder.CreateTable(
                name: "district",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор района (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    district_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название района (например, \"Центральный\")")
                },
                constraints: table =>
                {
                    table.PrimaryKey("district_pkey", x => x.id);
                },
                comment: "Хранит информацию о районах (например, административные районы города)");

            migrationBuilder.CreateTable(
                name: "microdistrict",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор микрорайона (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    microdistrict_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название микрорайона (например, \"Патриаршие пруды\")")
                },
                constraints: table =>
                {
                    table.PrimaryKey("microdistrict_pkey", x => x.id);
                },
                comment: "Хранит информацию о микрорайонах");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор роли (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Название роли (например, \"admin\", \"user\")")
                },
                constraints: table =>
                {
                    table.PrimaryKey("role_pkey", x => x.Id);
                },
                comment: "Хранит роли пользователей (например, администратор, пользователь)");

            migrationBuilder.CreateTable(
                name: "source",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор источника (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    source_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название сайта-источника (например, \"Авито\", \"ЦИАН\")"),
                    url = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Базовый URL сайта-источника"),
                    last_parsing_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Дата и время последнего парсинга источника")
                },
                constraints: table =>
                {
                    table.PrimaryKey("source_pkey", x => x.id);
                },
                comment: "Хранит информацию о сайтах-источниках объявлений");

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор статуса (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Название статуса (например, \"активно\", \"продано\", \"удалено\")")
                },
                constraints: table =>
                {
                    table.PrimaryKey("status_pkey", x => x.id);
                },
                comment: "Хранит статусы объявлений");

            migrationBuilder.CreateTable(
                name: "street",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор улицы (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Название улицы (например, \"Тверская улица\")")
                },
                constraints: table =>
                {
                    table.PrimaryKey("street_pkey", x => x.id);
                },
                comment: "Хранит информацию об улицах");

            migrationBuilder.CreateTable(
                name: "type_obj",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор типа объекта (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Название типа объекта (например, \"аренда\", \"продажа\")")
                },
                constraints: table =>
                {
                    table.PrimaryKey("type_obj_pkey", x => x.id);
                },
                comment: "Хранит типы объектов недвижимости (например, аренда, продажа)");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор пользователя (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Имя пользователя"),
                    surname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Фамилия пользователя"),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, comment: "Дата рождения пользователя"),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Email пользователя, используется для входа"),
                    phone_number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "Номер телефона пользователя"),
                    hash_password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Хэшированный пароль пользователя"),
                    role_id = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на роль пользователя (таблица role)"),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "Дата регистрации пользователя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_role",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Хранит информацию о зарегистрированных пользователях сервиса");

            migrationBuilder.CreateTable(
                name: "parsing_logs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор записи лога (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_source = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на источник (таблица source)"),
                    start_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP", comment: "Время начала парсинга"),
                    end_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, comment: "Время окончания парсинга"),
                    status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, comment: "Статус выполнения парсинга (success, failed, partial)"),
                    error_msg = table.Column<string>(type: "text", nullable: true, comment: "Сообщение об ошибке, если парсинг не удался"),
                    added_record = table.Column<int>(type: "integer", nullable: true, defaultValue: 0, comment: "Количество добавленных объявлений"),
                    update_record = table.Column<int>(type: "integer", nullable: true, defaultValue: 0, comment: "Количество обновлённых объявлений"),
                    deleted_record = table.Column<int>(type: "integer", nullable: true, defaultValue: 0, comment: "Количество помеченных как неактивные объявлений")
                },
                constraints: table =>
                {
                    table.PrimaryKey("parsing_logs_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_source",
                        column: x => x.id_source,
                        principalTable: "source",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Хранит логи работы парсера для мониторинга и отладки");

            migrationBuilder.CreateTable(
                name: "ad",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор объявления (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_id = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на тип объекта (таблица type_obj)"),
                    source_id = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на источник объявления (таблица source)"),
                    status_id = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на статус объявления (таблица status)"),
                    district_id = table.Column<int>(type: "integer", nullable: true, comment: "Ссылка на район (таблица district)"),
                    city_id = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на город (таблица city)"),
                    city_district_id = table.Column<int>(type: "integer", nullable: true, comment: "Ссылка на городской район (таблица city_district)"),
                    microdistrict_id = table.Column<int>(type: "integer", nullable: true, comment: "Ссылка на микрорайон (таблица microdistrict)"),
                    street_id = table.Column<int>(type: "integer", nullable: true, comment: "Ссылка на улицу (таблица street)"),
                    area_obj = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true, comment: "Площадь объекта в квадратных метрах"),
                    cost = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: true, comment: "Стоимость объекта в указанной валюте"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "Описание объявления"),
                    ad_num = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Номер дома"),
                    count_of_rooms = table.Column<int>(type: "integer", nullable: false),
                    stage = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ad_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_city",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_city_district",
                        column: x => x.city_district_id,
                        principalTable: "city_district",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_district",
                        column: x => x.district_id,
                        principalTable: "district",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_microdistrict",
                        column: x => x.microdistrict_id,
                        principalTable: "microdistrict",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_source",
                        column: x => x.source_id,
                        principalTable: "source",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_status",
                        column: x => x.status_id,
                        principalTable: "status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_street",
                        column: x => x.street_id,
                        principalTable: "street",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_type_obj",
                        column: x => x.type_id,
                        principalTable: "type_obj",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Хранит информацию об объявлениях о квартирах");

            migrationBuilder.CreateTable(
                name: "ad_parametres",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор параметра (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ad = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на объявление (таблица ad)"),
                    param_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false, comment: "Название параметра (например, \"этаж\", \"балкон\")"),
                    value_param = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "Значение параметра (например, \"5\", \"true\")")
                },
                constraints: table =>
                {
                    table.PrimaryKey("ad_parametres_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_ad",
                        column: x => x.id_ad,
                        principalTable: "ad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Хранит дополнительные параметры объявлений (например, этаж, наличие балкона)");

            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор записи избранного (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_user = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на пользователя (таблица user)"),
                    id_ad = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на объявление (таблица ad)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("favorites_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_ad",
                        column: x => x.id_ad,
                        principalTable: "ad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user",
                        column: x => x.id_user,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Хранит информацию об объявлениях, добавленных пользователями в избранное");

            migrationBuilder.CreateTable(
                name: "image_ad",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор изображения (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ad = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на объявление (таблица ad)"),
                    url_img = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false, comment: "URL изображения на сайте-источнике или в хранилище"),
                    основное = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false, comment: "Флаг, указывающий, является ли изображение основным для превью")
                },
                constraints: table =>
                {
                    table.PrimaryKey("image_ad_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_ad",
                        column: x => x.id_ad,
                        principalTable: "ad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Хранит изображения, связанные с объявлениями");

            migrationBuilder.CreateTable(
                name: "price_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false, comment: "Уникальный идентификатор записи в истории (автоинкремент)")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_ad = table.Column<int>(type: "integer", nullable: false, comment: "Ссылка на объявление (таблица ad)"),
                    price = table.Column<decimal>(type: "numeric(15,2)", precision: 15, scale: 2, nullable: false, comment: "Цена на момент записи"),
                    change_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP", comment: "Дата изменения цены")
                },
                constraints: table =>
                {
                    table.PrimaryKey("price_history_pkey", x => x.id);
                    table.ForeignKey(
                        name: "fk_ad",
                        column: x => x.id_ad,
                        principalTable: "ad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Хранит историю изменений цен для каждого объявления");

            migrationBuilder.CreateIndex(
                name: "idx_ad_city_id",
                table: "ad",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "idx_ad_source_id",
                table: "ad",
                column: "source_id");

            migrationBuilder.CreateIndex(
                name: "idx_ad_status_id",
                table: "ad",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "idx_ad_type_id",
                table: "ad",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_ad_city_district_id",
                table: "ad",
                column: "city_district_id");

            migrationBuilder.CreateIndex(
                name: "IX_ad_district_id",
                table: "ad",
                column: "district_id");

            migrationBuilder.CreateIndex(
                name: "IX_ad_microdistrict_id",
                table: "ad",
                column: "microdistrict_id");

            migrationBuilder.CreateIndex(
                name: "IX_ad_street_id",
                table: "ad",
                column: "street_id");

            migrationBuilder.CreateIndex(
                name: "unique_source_ad_num",
                table: "ad",
                columns: new[] { "source_id", "ad_num" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_ad_parametres_id_ad",
                table: "ad_parametres",
                column: "id_ad");

            migrationBuilder.CreateIndex(
                name: "unique_city_name",
                table: "city",
                column: "city_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_city_district_name",
                table: "city_district",
                column: "city_district_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_district_name",
                table: "district",
                column: "district_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_favorites_id_ad",
                table: "favorites",
                column: "id_ad");

            migrationBuilder.CreateIndex(
                name: "idx_favorites_id_user",
                table: "favorites",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "unique_user_ad",
                table: "favorites",
                columns: new[] { "id_user", "id_ad" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_image_ad_id_ad",
                table: "image_ad",
                column: "id_ad");

            migrationBuilder.CreateIndex(
                name: "unique_microdistrict_name",
                table: "microdistrict",
                column: "microdistrict_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_parsing_logs_id_source",
                table: "parsing_logs",
                column: "id_source");

            migrationBuilder.CreateIndex(
                name: "idx_price_history_id_ad",
                table: "price_history",
                column: "id_ad");

            migrationBuilder.CreateIndex(
                name: "unique_role_name",
                table: "role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_source_name",
                table: "source",
                column: "source_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_status_name",
                table: "status",
                column: "status_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_street_name",
                table: "street",
                column: "street_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unique_type_name",
                table: "type_obj",
                column: "type_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "unique_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ad_parametres");

            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "image_ad");

            migrationBuilder.DropTable(
                name: "parsing_logs");

            migrationBuilder.DropTable(
                name: "price_history");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "ad");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "city_district");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "microdistrict");

            migrationBuilder.DropTable(
                name: "source");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "street");

            migrationBuilder.DropTable(
                name: "type_obj");
        }
    }
}
