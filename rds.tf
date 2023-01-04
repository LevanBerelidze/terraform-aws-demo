resource "random_string" "db_password" {
  length           = 12
  special          = true
  override_special = "#%*@"
}

output "db_password" {
  value     = random_string.db_password.result
  sensitive = true
}

resource "aws_db_instance" "example_app_db" {
  engine                       = "mysql"
  engine_version               = "8.0"
  identifier                   = "example-app-db"
  username                     = var.db_master_username
  password                     = random_string.db_password.result
  instance_class               = "db.t3.micro"
  storage_type                 = "gp2"
  allocated_storage            = 20
  vpc_security_group_ids       = [aws_security_group.example_app_db.id]
  db_subnet_group_name         = aws_db_subnet_group.example_app.name
  publicly_accessible          = false
  auto_minor_version_upgrade   = true
  storage_encrypted            = false
  performance_insights_enabled = false
  deletion_protection          = false
  delete_automated_backups     = false
  skip_final_snapshot          = true
}
