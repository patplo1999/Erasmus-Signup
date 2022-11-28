import User from "models/User";
import { useState } from "react";
import ProfilePage from "./ProfilePage";

const ProfilePageContainer = () => {
  const [userData] = useState<User>({
    firstName: "Test",
    lastName: "Testowy",
    index: "244556",
    specialties: [
      {
        id: 1,
        name: "Coś tam i coś tam",
        grade: 3.56,
      },
      {
        id: 2,
        name: "Jakaś bardzo długa nazwa, w koncu to PWR",
        grade: 3.96,
      },
    ],
  });

  return <ProfilePage user={userData} />;
};

export default ProfilePageContainer;