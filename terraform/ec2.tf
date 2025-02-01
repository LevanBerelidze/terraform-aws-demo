data "aws_ami" "latest_ubuntu" {
  most_recent = true
  owners      = ["amazon"]

  filter {
    name   = "name"
    values = ["ubuntu/images/hvm-ssd/ubuntu-jammy-22.04-amd64-server-20221201"]
  }
}

output "ami_id" {
  value = data.aws_ami.latest_ubuntu.id
}

resource "aws_instance" "example_app" {
  ami                         = data.aws_ami.latest_ubuntu.id
  vpc_security_group_ids      = [aws_security_group.example_app.id]
  instance_type               = "t2.micro"
  key_name                    = var.ec2_key_pair_name
  associate_public_ip_address = true
  subnet_id                   = aws_subnet.example_app_public.id

  tags = {
    Name = "example_app"
  }
}
